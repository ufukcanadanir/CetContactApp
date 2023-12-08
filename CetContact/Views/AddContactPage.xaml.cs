using CetContact.Model;

namespace CetContact.Views;

public partial class AddContactPage : ContentPage
{
    ContactRepository contactRepository;
	public AddContactPage()
	{
		InitializeComponent();
        contactRepository = new ContactRepository();
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		//Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        //Shell.Current.GoToAsync("//"+nameof(ContactsPage));
       
        Shell.Current.GoToAsync("..");

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) && string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Error", $"Following fields can not be empty: {NameEntry} & {EmailEntry}?", "OK");
        }
        else
        {
        ContactInfo contact = new ContactInfo
        {
            Name = NameEntry.Text,
            Phone = PhoneEntry.Text,
            Address = AdressEntry.Text,
            Email = EmailEntry.Text,
        };
        

        await contactRepository.AddContact(contact);
        await Shell.Current.GoToAsync("..");
        }
    }
}