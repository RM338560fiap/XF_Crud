using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XF_Crud
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Get All Persons
            List<Alunos> personList = new List<Alunos>();
            personList = await App.SQLiteDb.GetItemsAsync();
            if (personList.Count>0)
            {
                lstPersons.ItemsSource = personList;
            }

        }


        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Alunos person = new Alunos()
                {
                    Nome = txtName.Text
                };

                //Add New Person
                await App.SQLiteDb.SaveItemAsync(person);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Matricula Incluida com Sucesso", "OK");
                //Get All Persons
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Obrigatorio", "Informe o Nome!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    txtName.Text = person.Nome;
                    await DisplayAlert("Success", "Person Name: " + person.Nome, "OK");
                }
            }
            else
            {
                await DisplayAlert("Obrigatorio", "Informe a Matricula", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                Alunos person = new Alunos()
                {
                    MatriculaId = Convert.ToInt32(txtPersonId.Text),
                    Nome = txtName.Text
                };

                //Update Person
                await App.SQLiteDb.SaveItemAsync(person);

                txtPersonId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated Successfully", "OK");

                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }

            }
            else
            {
                await DisplayAlert("Obrigatorio", "Informe a Matricula", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    //Delete Person
                    await App.SQLiteDb.DeleteItemAsync(person);
                    txtPersonId.Text = string.Empty;
                    await DisplayAlert("Success", "Matricula Deletada", "OK");

                    //Get All Persons
                    var personList = await App.SQLiteDb.GetItemsAsync();
                    if (personList != null)
                    {
                        lstPersons.ItemsSource = personList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Obrigatorio", "Informe a Matricula", "OK");
            }
        }
    }
}
