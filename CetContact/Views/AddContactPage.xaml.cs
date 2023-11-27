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
}