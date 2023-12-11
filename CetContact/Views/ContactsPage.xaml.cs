using CetContact.Model;
using System.Collections.ObjectModel;

namespace CetContact.Views;

public partial class ContactsPage : ContentPage
{
    ContactRepository contactRepository;
	public ContactsPage()
	{
		InitializeComponent();
		contactRepository = new ContactRepository();
		
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contacts =new ObservableCollection<ContactInfo>( await contactRepository.GetAllContacts());
        ContactsList.ItemsSource = contacts;

    }
    private void AddContactButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddContactPage));
       
    }

    private void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(ContactsList.SelectedItem != null)
		{
            
			ContactInfo selectedContact= ContactsList.SelectedItem as ContactInfo;
            int selectedID= selectedContact.Id;
            Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={selectedID}"); //EditContactPage?id=2

            ContactsList.SelectedItem = null;


            // DisplayAlert("You Clicked", $"//{nameof(EditContactPage)}?id={selectedID}", "ok");



        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if(sender is Button button && button.BindingContext is ContactInfo selectedContact)
        {

            bool result = await DisplayAlert("Confirmation", $"Are you sure you want to delete {selectedContact.Name}?", "Yes", "Cancel");

			if(result)
			{
               await contactRepository.RemoveContact(selectedContact);

                LoadContacts();
			}
            else
            {
                await Shell.Current.GoToAsync("//ContactsPage");

            }
        }
        }


    private async void LoadContacts()
    {
        var contacts= new ObservableCollection<ContactInfo>(await contactRepository.GetAllContacts());
        ContactsList.ItemsSource= contacts;
    }
    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        var searchedContacts =new ObservableCollection<ContactInfo>(await contactRepository.SearchContacts(searchBar.Text));
        ContactsList.ItemsSource = searchedContacts;
    }
}