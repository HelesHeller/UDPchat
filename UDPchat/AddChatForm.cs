using System;
using System.Windows.Forms;

namespace TCPChat
{
    public partial class AddChatForm : Form
    {
        public string ChatName { get; private set; }  // Public property to access the name of the chat

        public AddChatForm()
        {
            InitializeComponent();
        }

        // Event handler for the Create Chat button
        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            // Check if the text box is not empty
            if (!string.IsNullOrWhiteSpace(txtChatName.Text))
            {
                ChatName = txtChatName.Text;  // Set the ChatName property
                this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
                this.Close();  // Close the form
            }
            else
            {
                MessageBox.Show("Please enter a chat name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back to the text box for the user to enter a name
                txtChatName.Focus();
            }
        }
    }
}
