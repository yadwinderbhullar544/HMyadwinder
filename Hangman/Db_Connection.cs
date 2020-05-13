using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Hangman.Resources;
using Mono.Data.Sqlite;
using Environment = Android.OS.Environment;


namespace Hangman
{
   public  class Db_Connection
    {

       private string db_path { get; set; }

      private SQLiteConnection db_DataBase { get; set; }

      



           public Db_Connection()
       {

           string db_path =
               Path.Combine(System.Environment.GetFolderPath
                   (System.Environment.SpecialFolder.Personal), "Game_DataBase.sqlite");

            db_DataBase = new SQLiteConnection(db_path);

            db_DataBase.CreateTable<MClass>();
       }




        public List<MClass> ViewAll()
        {
            try
            {
               ;
                return db_DataBase.Query<MClass>("select *  from HangmanScore  ORDER BY Score DESC");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }







        public string UpdateScore(int id, string name, int score)
        {

         
              try
                {
                    string db_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        "Game_DataBase.sqlite");
                var db = new SQLiteConnection(db_path);
                    var item = new MClass();

                    item.Id = id;
                    item.Name = name;
                    item.Score = score;
                  
                    db.Update(item);
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return "Error : " + ex.Message;
                }
            
        }



        public string InsertNewPlayer(string name, int score)
        {


            try
            {
                string db_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Game_DataBase.sqlite");
                var db = new SQLiteConnection(db_path);
                var item = new MClass();
                item.Name = name;
                item.Score = score;

                db.Insert(item);
                return "Data Saved";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }


       public string DeletePlayer(int id)
       {

            try
            {
                string db_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Game_DataBase.sqlite");
                var db = new SQLiteConnection(db_path);
                var item = new MClass();
                item.Id = id;
              

                db.Delete(item);
                return "Daleted";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }


        }

   }
    }
