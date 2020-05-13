using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman.Assets;
using Hangman.Resources;
using Java.Security;
using DataAdapter = System.Data.Common.DataAdapter;

namespace Hangman
{
    [Activity(Label = "New Player")]
    public class New_Player : Activity

    {
        List<MClass> List_Names;
       
        public TextView txt_Name_;
        private Spinner Name_Score_Spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.New_Palyer);

            Db_Connection myConnectionClass = new Db_Connection();
            List_Names = myConnectionClass.ViewAll();

            Name_Score_Spinner = FindViewById<Spinner>(Resource.Id.Spinnner_select);
            Hangman.Resources.DataAdapter da = new Resources.DataAdapter(this, List_Names);

            Name_Score_Spinner.Adapter = da;

            Name_Score_Spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            txt_Name_ = FindViewById<TextView>(Resource.Id.txt_Name);

            Button btn_Play_Game = FindViewById<Button>(Resource.Id.btn_Play_Game);
            btn_Play_Game.Click += btn_Play_Game_Click;


            Button btn_save = FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += btn_save_Click;

            Button btn_Home_Page = FindViewById<Button>(Resource.Id.btn_Home_Page);

            btn_Home_Page.Click += btn_Home_Page_Click;

        }

        private void btn_Home_Page_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btn_Play_Game_Click(object sender, EventArgs e)
        {
           StartActivity(typeof(HangmanGame));
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
             // If text contains characters
            if (txt_Name_.Text.Length > 0)
            {
                // Name=textfield
                HangmanGame.PlayerName = txt_Name_.Text.ToString();
                // default score 0
                HangmanGame.score = 0;
                var cc = new Db_Connection();
                // Insert the name and score into the table of sqlite database
                cc.InsertNewPlayer(HangmanGame.PlayerName, HangmanGame.score);

                // Show all list
                List_Names = cc.ViewAll();

            
                var da = new Resources.DataAdapter(this, List_Names);
                // Data In spinner
                Name_Score_Spinner.Adapter = da;
                
            }
            // If text name is blank
            else
            {


                Toast.MakeText(this, "Please Fill Name", ToastLength.Short).Show();
            }
        }


        


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner) sender;
            // Name and his score in spinner 
            HangmanGame.Id = this.List_Names.ElementAt(e.Position).Id;
            HangmanGame.PlayerName = this.List_Names.ElementAt(e.Position).Name;
            HangmanGame.score = this.List_Names.ElementAt(e.Position).Score;
        }


     
    


        
    }
}