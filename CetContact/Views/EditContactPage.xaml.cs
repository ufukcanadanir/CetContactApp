namespace CetContact.Views;

[QueryProperty(nameof(ContactId),"id")]
public partial class EditContactPage : ContentPage
{
    private string contactId;

    public EditContactPage()
	{
		InitializeComponent();
	}

    public string ContactId {
        get => contactId; 
        set {
            contactId = value;
            ContactIdLabel.Text = contactId;
        
        } }
}