/*
    Written by Vedant Sudhir Nibandhe for CS6326.001
    For Assignment 2 - Rebate Form starting February 12, 2023.
    Netid: vxn200012

    This program is for keeping a record of rebates. User purchase information and contact 
    information is entered into system to claim rebate on purchased product.
    Added list of entries are displayed on the left side of the screen. 

    Input fields on the form are:
        First Name
        Middle Initial - optional
        Last Name
        Address Line 1
        Address Line 2 - optional
        City
        State
        Zip code
        Gender - optional
        Phone number
        Email address
        Proof of purchase attached
        Date received

    Functionality:
        The Program starts off by blank form and no entries so far on the left side.
        As soon as we enter the information for rebate and press save, the program adds 
        it to the UI and displays the entry on the left hand side in a list view format.
        Similarly, it saves the rebate to a text file on the backend. Other features like,
        modifying the rebate can be done by clicking on a record 
        and performing necessary modifications and then pressing Save button.
        Rebate records can be deleted by selecting a record from the list and pressing the 
        delete button.
        Similarly, at any point, the form can be cleared by pressing the clear button.
    
    Background processing:
        Validation is performed on fields like phone number, email is done at the runtime before clicking save  as well as after pressing Save. 
        Date received is defaulted to today but it can be changed. But it cannot be set to a future date.
        Whenever we modify a record and press save, the old record from which the new record was taken will be deleted(from list as well as the file) and a new record will be added to the file and the list.
        Duplicate records with same combination of first name, last name, phone number are restricted.
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Asg2_vxn200012
{
    public partial class rebateForm : Form
    {
        protected string timeForFirstChar;
        protected int backSpaceCount;
        protected FileIOUtilities filehandler;
        public rebateForm()
        {
            filehandler = new FileIOUtilities();
            InitializeComponent();
        }

        //Initial function that loads the rebate form.
        private void rebateForm_Load(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            deleteButton.Enabled = false;
            displayDetailsView.View = View.Details;
            displayDetailsView.Columns.Add("Name");
            displayDetailsView.Columns.Add("Phone Number", 100);
            //filehandler = new FileIOUtilities();
             string[] readText = filehandler.ReadFile();
             foreach (string stringLine in readText)
             {
                 Console.WriteLine(stringLine);
                 AddToListView(stringLine);
             }
             dateReceived.MaxDate = DateTime.Now;
            
            
        }

        /*
         * Records the time at which the user starts typing in the form.
         * Changes status label from "Add New data" to "Adding New Data"
         */ 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timeForFirstChar = DateTime.Now.Hour.ToString() + ":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString();
            //String timeStamp = DateTime.Now.
            if (statusLabel.Text.Equals("Add New Data"))
            {
                statusLabel.Text = "Adding New Data";
            }
            else if(statusLabel.Text.Equals("Modify Data"))
            {
                statusLabel.Text = "Modifying Existing Data";
            }
            saveButton.Enabled = true;
        }

        /*
         * Deals with two functionalities - Add and Modify
         * Supports changing of status labels to Adding or Modifying a record so that the user will be aware of his actions.
         * Works with other modules written below to validate and write data to field and UI.
         */
        private void saveButton_Click(object sender, EventArgs e)
        {   
            //time at which user pressed save button
            string saveButtonTime = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            //for add data
            if (statusLabel.Text.Equals("Adding New Data"))
            {
                //change id value
                int numberOfrecords = displayDetailsView.Items.Count + 1;
                string id = numberOfrecords.ToString();

                //Checking input validity before submitting
                ValidateInputs validateInputs = new ValidateInputs();
                if (!validateInputs.validateFields(firstName.Text, lastName.Text, cityBox.Text, zipCode.Text, phoneNumber.Text, emailAddress.Text, addLine1.Text))
                {
                    MessageBox.Show("Recheck all errors before submitting. Press OK to go back to form.");
                }
                else
                {
                    //check for duplicate records
                    string[] fileContents = filehandler.ReadFile();
                    foreach (string fileLine in fileContents)
                    {
                        string[] entry = fileLine.Split('\t');
                        string actualFirstName = entry[1];
                        string actualMiddleName = entry[2];
                        string actualLastName = entry[3];
                        string phoneNo = entry[10];
                        string actualFullName = actualFirstName + " " + actualMiddleName + " " + actualLastName;
                        string currentFullName = firstName.Text + " " + midName.Text + " " + lastName.Text;
                        Console.WriteLine();
                        if (actualFullName.ToLower().Equals(currentFullName.ToLower()) && phoneNo.Equals(phoneNumber.Text))
                        {
                            MessageBox.Show("Record already present. Please enter new data");
                            return;
                        }


                    }
                    string recordToAdd = id + '\t' + firstName.Text + '\t' + midName.Text + '\t' + lastName.Text + '\t' + addLine1.Text + '\t' +
                        addLine2.Text + '\t' + cityBox.Text + '\t' + stateBox.Text + '\t' + zipCode.Text + '\t' + gender.Text + '\t' +
                        phoneNumber.Text + '\t' + emailAddress.Text + '\t' + yesRButton.Checked.ToString() + '\t' + noRButton.Checked.ToString() + '\t' +
                        dateReceived.Value + '\t' + timeForFirstChar + '\t' + saveButtonTime + '\t' + backSpaceCount.ToString(); 
                    try
                    {
                        filehandler.WriteRecordToFile(recordToAdd);
                        AddToListView(recordToAdd);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                    statusLabel.Text.Equals("Add New Data");
                    ClearForm();
                }
            }

            //else is triggered when we select an item in the listview and want to modify it.
            else
            {
                //extract phone number and name from selected item
                string fullName = "", predphoneNumber = "";
                foreach (ListViewItem itemRow in displayDetailsView.SelectedItems)
                {
                    fullName = itemRow.SubItems[0].Text;
                    predphoneNumber = itemRow.SubItems[1].Text;
                    //Console.WriteLine(fullName + " " + predphoneNumber);
                }

                //retrieve that record from file 
                string[] fileContent = filehandler.ReadFile();
                string timeForFirstCharOld = "";
                string saveButtonTimeOld = "";
                string backSpaceCountFromFile = "0";
                string matchedName = "";
                string phoneN = "";
                foreach(string fileLine in fileContent)
                {
                    string[] entry = fileLine.Split('\t');
                    string actualFirstName = entry[1];
                    string actualMiddleName = entry[2];
                    string actualLastName = entry[3];
                    string actualFullName = actualFirstName + " " + actualMiddleName + " " + actualLastName;
                    string actualAddLine1 = entry[4];
                    string actualAddLine2 = entry[5];
                    string actualCity = entry[6];
                    string actualState = entry[7];
                    string zipCode = entry[8];
                    string gend = entry[9];
                    string phoneNo = entry[10];
                    string emaila = entry[11];
                    string yButtonVal = entry[12];
                    string nButtonVal = entry[13];
                    timeForFirstCharOld = entry[15];
                    saveButtonTimeOld = entry[16];
                    backSpaceCountFromFile = entry[17];
                    
                    if (actualFullName.ToLower().Equals(fullName.ToLower()) && phoneNo.Equals(predphoneNumber))
                    {
                        matchedName = actualFullName;
                        phoneN = phoneNo;
                        break;
                    }
                }
                ValidateInputs validateInputs = new ValidateInputs();
                if (!validateInputs.validateFields(firstName.Text, lastName.Text, cityBox.Text, zipCode.Text, phoneNumber.Text, emailAddress.Text, addLine1.Text))
                {
                    MessageBox.Show("Recheck all errors before submitting. Press OK to go back to form.");
                }
                else
                {
                    //prepare data using newly changed fields
                    string recordToWrite = "10" + '\t' + firstName.Text + '\t' + midName.Text + '\t' + lastName.Text + '\t' + addLine1.Text + '\t' +
                    addLine2.Text + '\t' + cityBox.Text + '\t' + stateBox.Text + '\t' + zipCode.Text + '\t' + gender.Text + '\t' +
                    phoneNumber.Text + '\t' + emailAddress.Text + '\t' + yesRButton.Checked.ToString() + '\t' + noRButton.Checked.ToString() + '\t' + dateReceived.Value + '\t' + 
                    timeForFirstCharOld + '\t' + saveButtonTimeOld + '\t' + backSpaceCountFromFile;
                    //if after this, the data is same then return 
                    string newFullName = firstName.Text + " " + midName.Text + " " + lastName.Text;
                    string newPhoneNumber = phoneNumber.Text;
                    if (matchedName.ToLower().Equals(newFullName.ToLower()) && phoneN.Equals(newPhoneNumber))
                    {
                        MessageBox.Show("Record already present. Please enter new data");
                        return;
                    }
                    else
                    {
                        displayDetailsView.Items.Remove(displayDetailsView.SelectedItems[0]);
                        string[] fileContents = filehandler.ReadFile();
                        filehandler.WriteRecordsToFileAfterModification(fileContents, matchedName, phoneN, recordToWrite);
                        AddToListView(recordToWrite);
                        ClearForm();
                    }
                }
            }  
        }

        /*
         * Clears the forms and resets all the fields when the clear button on UI is pressed.
         */
        private void ClearForm()
        {
            saveButton.Enabled = false;
            deleteButton.Enabled = false;
            firstName.Clear();
            lastName.Clear();
            midName.Clear();
            addLine1.Clear();
            addLine2.Clear();
            cityBox.Clear();
            stateBox.Clear();
            zipCode.Clear();
            gender.Clear();
            phoneNumber.Clear();
            emailAddress.Clear();
            statusLabel.Text = "Add New Data";
            yesRButton.Checked = false;
            noRButton.Checked = false;
            dateReceived.Value = DateTime.Today;
            firstName.ReadOnly = false;
            midName.ReadOnly = false;
            lastName.ReadOnly = false;
            phoneNumber.ReadOnly = false;
            backSpaceCount = 0;
        }

        //Calls ClearForm method
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        /*Below function is triggered when an item in the listview is selected for deletion or modification.
         * The function retrieves the selected item's data from the txt file and populates all the fields in the form for the user to modify.
         */
        private void displayDetailsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            deleteButton.Enabled = true;

            //displayDetailsView.SelectedItems[0].SubItems.ToString();
            string fullName = "", predphoneNumber = "";
            foreach (ListViewItem itemRow in displayDetailsView.SelectedItems)
            {
                fullName = itemRow.SubItems[0].Text;
                predphoneNumber = itemRow.SubItems[1].Text;
                Console.WriteLine(fullName + " " + predphoneNumber);
            }
            string[] fileContents = filehandler.ReadFile();
            foreach(string fileLine in fileContents)
            {
                
                string[] entry = fileLine.Split('\t');
                string actualFirstName = entry[1];
                string actualMiddleName = entry[2];
                string actualLastName = entry[3];
                string actualFullName = actualFirstName + " " + actualMiddleName + " " + actualLastName;
                string actualAddLine1 = entry[4];
                string actualAddLine2 = entry[5];
                string actualCity = entry[6];
                string actualState = entry[7];
                string zipCode = entry[8];
                string gend = entry[9];
                string phoneNo = entry[10];
                string emaila = entry[11];
                string yButtonVal = entry[12];
                string nButtonVal = entry[13];
                string dateTimePickerValue = entry[14];
                if (actualFullName.ToLower().Equals(fullName.ToLower()) && phoneNo.Equals(predphoneNumber))
                {
                    Console.WriteLine("Match");
                    firstName.Text = actualFirstName;
                    midName.Text = actualMiddleName;
                    lastName.Text = actualLastName;
                    addLine1.Text = actualAddLine1;
                    addLine2.Text = actualAddLine2;
                    cityBox.Text = actualCity;
                    stateBox.Text = actualState;
                    this.zipCode.Text = zipCode;
                    gender.Text = gend;
                    phoneNumber.Text = phoneNo;
                    emailAddress.Text = emaila;
                    dateReceived.Value = DateTime.Parse(dateTimePickerValue);
                    if (yButtonVal.Equals("True")) {
                        yesRButton.Checked = true;
                        noRButton.Checked = false;

                    }
                    else
                    {
                        yesRButton.Checked = false;
                        noRButton.Checked = true;
                    }
                }
            }
            statusLabel.Text = "Modify or Delete a Record";
        }

        //Adds items to List view on the UI
        public void AddToListView(string recordToAdd)
        {
            string[] entry = recordToAdd.Split('\t');
            string fullName = entry[1] + " " + entry[2] + " " + entry[3];
            string phoneNumber = entry[10];
            string[] details = new string[2];
            details[0] = fullName;
            details[1] = phoneNumber;
            ListViewItem personDetail = new ListViewItem(details);
            displayDetailsView.Items.Add(personDetail);
        }

        //Keeps track of Backspace counts
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == '\b')
            {
                backSpaceCount = backSpaceCount + 1;
            }
        }


        //function to validate email address at runtime
        private void emailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(emailAddress.Text))
            {
                errorProvider.SetError(emailAddress, "Please enter your email address");
                saveButton.Enabled = false;
            }
            else if (!validateEnteredEmail(emailAddress.Text))
            {
                errorProvider.SetError(emailAddress, "Entered Email is Invalid");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(emailAddress, null);
                saveButton.Enabled = true;
            }
        }

        //utility function to check email format
        public bool validateEnteredEmail(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        //function to validate first name at runtime
        private void firstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(firstName.Text))
            {
                errorProvider.SetError(firstName, "First name cannot be left blank.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(firstName, null);
            }
            
        }


        //function to validate last name at runtime
        private void lastName_Validating(object sender, CancelEventArgs e)
        {
            double result;
            if (string.IsNullOrEmpty(lastName.Text))
            {
                errorProvider.SetError(lastName, "Last name cannot be left blank.");
            }
            else if (double.TryParse(lastName.Text.ToString(), out result))
            {
                errorProvider.SetError(lastName, "Invalid characters in Last Name! Please recheck.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(lastName, null);
            }
        }

        //function to validate address line 1 at runtime
        private void addLine1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(addLine1.Text))
            {
                errorProvider.SetError(addLine1, "Address cannot be left blank.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(addLine1, null);
            }
        }

        //function to validate city field at runtime
        private void cityBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cityBox.Text))
            {
                errorProvider.SetError(cityBox, "City name cannot be left blank.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cityBox, null);
            }
        }

        //function to validate state field at runtime
        private void stateBox_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(stateBox.Text))
            {
                errorProvider.SetError(stateBox, "State name cannot be left blank.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(stateBox, null);
            }
        }

        //Function to delete records
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (displayDetailsView.SelectedItems.Count > 0)
            {
                //handle deleting the entry from text file and write back to text file
                string fullName = "", predphoneNumber = "";
                foreach (ListViewItem itemRow in displayDetailsView.SelectedItems)
                {
                    fullName = itemRow.SubItems[0].Text;
                    predphoneNumber = itemRow.SubItems[1].Text;
                    Console.WriteLine(fullName + " " + predphoneNumber);
                }
                displayDetailsView.Items.Remove(displayDetailsView.SelectedItems[0]);
                string[] fileContents = filehandler.ReadFile();
                filehandler.WriteRecordsAfterDeletion(fileContents, fullName, predphoneNumber);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Invalid Delete Operation!");
            }
        }
    }

    /*Class that does validation for us after Save button is pressed */
    public class ValidateInputs
    {
        public bool isValid;
        public ValidateInputs()
        {
            isValid = false;
        }

        //Wrapper function to call other validator functions
        public bool validateFields(string firstName, string lastName, string city, string zipCode, string phoneNumber, string email, string address)
        {
            if (validateFirstName(firstName) && validateLastName(lastName) && validateAddress(address) && validateCity(city) && validateZipcode(zipCode) && validatePhoneNumber(phoneNumber) && validateEmail(email))
            {
                isValid = true;
            }
            return isValid;
        }

        //function to validate first name after submit button is pressed
        private bool validateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First Name cannot be left blank. Press OK");
                return false;
            }
            else if (!Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("First name should contain only letters. No digits allowed. Press OK");
                return false;
            }
            return true;
        }

        //function to validate last name after submit button is pressed
        private bool validateLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Last Name cannot be left blank. Press OK");
                return false;
            }
            else if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Last name should contain only letters. No digits allowed. Press OK");
                return false;
            }
            return true;
        }

        //function to validate city field after submit button is pressed
        private bool validateCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("City Name cannot be left blank. Press OK");
                return false;
            }
            if (!Regex.IsMatch(city, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("City name should contain only letters. No digits allowed. Press OK");
                return false;
            }
            return true;
        }

        //function to validate phone number after submit button is pressed
        private bool validatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length < 10)
            {
                MessageBox.Show("Invalid phone number. 10 digits expected. Press OK.");
                return false;
            }
            else if (!Regex.IsMatch(phoneNumber, @"^[0-9]+$"))
            {
                MessageBox.Show("Phone Number should not contain letters.Press OK");
                return false;
            }
            else
            {
                return true;
            }
        }

        //function to validate zipcode field after submit button is pressed
        private bool validateZipcode(string zipCode)
        {
            if ((int)zipCode.Length != 5 && (int)zipCode.Length != 9)
            {
                MessageBox.Show("Zipcode length should be either 5 or 9. Press OK.");
                return false;
            }
            else if (!Regex.IsMatch(zipCode, @"^[0-9]+$"))
            {
                MessageBox.Show("Zipcode should not contain letters.Press OK");
                return false;
            }
            else
            {
                return true;
            }
        }

        //function to validate email after submit button is pressed
        private bool validateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email cannot be empty. Press OK.");
                return false;
            }
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Invalid Email.Press OK");
                return false;
            }
            else
            {
                return true;
            }
        }

        //function to validate address line 1 after submit button is pressed
        private bool validateAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address cannot be left blank. Press OK.");
            }
            return true;
        }
    }

    //Class for handling File input/output
    public class FileIOUtilities
    {
        public string filePath;
        public FileIOUtilities()
        {
            filePath = Environment.CurrentDirectory + "/" + "CS6326Asg2.txt";
        }

        //function to read file and return file contents
        public string[] ReadFile()
        {
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.CreateText(filePath);
                return new string[] { };
            }
            else
            {
                string[] readText = System.IO.File.ReadAllLines(filePath);
                return readText;    
            }
        }

        //function to write a record to the file while adding
        public void WriteRecordToFile(string recordToAdd)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.CreateText(filePath);
                }
                else
                {
                    string[] readText = System.IO.File.ReadAllLines(filePath);
                    //readText.Append(recordToAdd);
                    System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
                    foreach (string lol in readText)
                    {
                        file.WriteLine(lol);
                        Console.WriteLine(lol);
                    }

                    //System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
                    file.WriteLine(recordToAdd);
                    file.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //function to write a record to the file while modifying
        public void WriteRecordsToFileAfterModification(string[] fileContents, string matchedName, string phoneN, string recordToWrite)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            foreach (string fileLine in fileContents)
            {

                string[] entry = fileLine.Split('\t');
                string actualFirstName = entry[1];
                string actualMiddleName = entry[2];
                string actualLastName = entry[3];
                string actualFullName = actualFirstName + " " + actualMiddleName + " " + actualLastName;

                string phoneNo = entry[10];

                if (!actualFullName.ToLower().Equals(matchedName.ToLower()) && !phoneNo.Equals(phoneN))
                {
                    file.WriteLine(fileLine);
                }
            }
            file.WriteLine(recordToWrite);
            file.Close();
        }

        //function to write a record to the file while deleting
        public void WriteRecordsAfterDeletion(string[] fileContents, string fullName, string predphoneNumber)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            foreach (string fileLine in fileContents)
            {
                string[] entry = fileLine.Split('\t');
                string actualFirstName = entry[1];
                string actualMiddleName = entry[2];
                string actualLastName = entry[3];
                string actualFullName = actualFirstName + " " + actualMiddleName + " " + actualLastName;
                string phoneNo = entry[10];

                if (!actualFullName.ToLower().Equals(fullName.ToLower()) && !phoneNo.Equals(predphoneNumber))
                {
                    file.WriteLine(fileLine);
                }
            }
            file.Close();
        }
    }
}