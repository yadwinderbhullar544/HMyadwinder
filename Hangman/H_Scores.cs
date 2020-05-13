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
using Hangman.Resources;

namespace Hangman
{
    [Activity(Label = "High Score")]
    public class H_Scores : Activity
    {
        List<MClass> myList;
      public Db_Connection myConnectionClass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View_High_Scores);
          
            myConnectionClass = new Db_Connection();          
            myList = myConnectionClass.ViewAll();           
           
            Button btn_Home = FindViewById<Button>
                (Resource.Id.btn_Home);

            btn_Home.Click += btn_Home_Click;

            // Name with High Score
            ListView Lv_HighScore = FindViewById<ListView>(Resource.Id.Lv_HighScore);
            Lv_HighScore.Adapter = new DataAdapter(this, myList);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}