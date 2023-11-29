using CetContact.Model;

namespace CetContact.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		//Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        //Shell.Current.GoToAsync("//"+nameof(ContactsPage));
       
        Shell.Current.GoToAsync("..");

    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        ContactInfo contact = new ContactInfo
        {
            Name = NameEntry.Text,
            Phone = PhoneEntry.Text,
            Address = AdressEntry.Text,
            Email = EmailEntry.Text,
        };
    }
}