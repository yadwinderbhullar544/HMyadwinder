using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using Stream = System.IO.Stream;
using Android.App;
using Android.Content;
using Android.Drm;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Hangman.Resources;
using Java.Security;


namespace Hangman.Assets
{
    [Activity(Label = "Play Game")]
    public class HangmanGame : Activity
   
    {
        private Button btn_Home_Page;
        private Button btn_Play_Game;
        private TextView txtWordToGuess;
       
        private ImageView img_wrongs;
        private TextView txtCurrentScore;
        private TextView txtGuessesLeft;


        //All Buttons
        private Button btn_A;
        private Button btn_B;
        private Button btn_C;
        private Button btn_D;
        private Button btn_E;
        private Button btn_F;
        private Button btn_G;
        private Button btn_H;
        private Button btn_I;
        private Button btn_J;
        private Button btn_K;
        private Button btn_L;
        private Button btn_M;
        private Button btn_N;
        private Button btn_O;
        private Button btn_P;
        private Button btn_Q;
        private Button btn_R;
        private Button btn_S;
        private Button btn_T;
        private Button btn_U;
        private Button btn_V;
        private Button btn_W;
        private Button btn_X;
        private Button btn_Y;
        private Button btn_Z;

        
     
       

        public static int Id;
        public static string PlayerName;
        public static int score;
        private string letter;
        private string rand;

        private int GuessesLeft = 8;

        private char[] wordToGuess;
        private char[] HiddenWord;

        private bool GuessedCorrect;

        private List<string> wordList = new List<string>();

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Play_Game);
            LoadWords();


            btn_Play_Game = FindViewById<Button>(Resource.Id.btn_Play_Game);
            btn_Play_Game.Click += btn_Play_Game_Click;

            txtWordToGuess = FindViewById<TextView>(Resource.Id.txtWordToGuess);
           
            btn_Home_Page = FindViewById<Button>(Resource.Id.btn_Home_Page);
            btn_Home_Page.Click += btn_Home_Page_Click;


            txtCurrentScore = FindViewById<TextView>(Resource.Id.txtCurrentScore);
            txtCurrentScore.Text = score.ToString();

            txtGuessesLeft = FindViewById<TextView>(Resource.Id.txtGuessesLeft);
            txtGuessesLeft.Text = GuessesLeft.ToString();


            btn_A = FindViewById<Button>(Resource.Id.btn_A);
            btn_B = FindViewById<Button>(Resource.Id.btn_B);
            btn_C = FindViewById<Button>(Resource.Id.btn_C);
            btn_D = FindViewById<Button>(Resource.Id.btn_D);
            btn_E = FindViewById<Button>(Resource.Id.btn_E);
            btn_F = FindViewById<Button>(Resource.Id.btn_F);
            btn_G = FindViewById<Button>(Resource.Id.btn_G);
            btn_H = FindViewById<Button>(Resource.Id.btn_H);
            btn_I = FindViewById<Button>(Resource.Id.btn_I);
            btn_J = FindViewById<Button>(Resource.Id.btn_J);
            btn_K = FindViewById<Button>(Resource.Id.btn_K);
            btn_L = FindViewById<Button>(Resource.Id.btn_L);
            btn_M = FindViewById<Button>(Resource.Id.btn_M);
            btn_N = FindViewById<Button>(Resource.Id.btn_N);
            btn_O = FindViewById<Button>(Resource.Id.btn_O);
            btn_P= FindViewById<Button>(Resource.Id.btn_P);
            btn_Q = FindViewById<Button>(Resource.Id.btn_Q);
            btn_R = FindViewById<Button>(Resource.Id.btn_R);
            btn_S = FindViewById<Button>(Resource.Id.btn_S);
            btn_T = FindViewById<Button>(Resource.Id.btn_T);
            btn_U= FindViewById<Button>(Resource.Id.btn_U);
            btn_V = FindViewById<Button>(Resource.Id.btn_V);
            btn_W = FindViewById<Button>(Resource.Id.btn_W);
            btn_X = FindViewById<Button>(Resource.Id.btn_X);
            btn_Y = FindViewById<Button>(Resource.Id.btn_Y);
            btn_Z = FindViewById<Button>(Resource.Id.btn_Z);
           
            All_Disable_Buttons();  //All Buttons Disable 
            img_wrongs = FindViewById<ImageView>(Resource.Id.img_wrongs);
            Load_blank_Image();

            // Button Click Event .
            btn_A.Click += Letter_Click;
            btn_B.Click += Letter_Click;
            btn_C.Click += Letter_Click;
            btn_D.Click += Letter_Click;
            btn_E.Click += Letter_Click;
            btn_F.Click += Letter_Click;
            btn_G.Click += Letter_Click;
            btn_H.Click += Letter_Click;
            btn_I.Click += Letter_Click;
            btn_J.Click += Letter_Click;
            btn_K.Click += Letter_Click;
            btn_L.Click += Letter_Click;
            btn_M.Click += Letter_Click;
            btn_N.Click += Letter_Click;
            btn_O.Click += Letter_Click;
            btn_P.Click += Letter_Click;
            btn_Q.Click += Letter_Click;
            btn_R.Click += Letter_Click;
            btn_S.Click += Letter_Click;
            btn_T.Click += Letter_Click;
            btn_U.Click += Letter_Click;
            btn_V.Click += Letter_Click;
            btn_W.Click += Letter_Click;
            btn_X.Click += Letter_Click;
            btn_Y.Click += Letter_Click;
            btn_Z.Click += Letter_Click;

        }

      
        private void btn_Home_Page_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

       
        private void Letter_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            // the variable clickbutton references the button  that was clicked
            var clickedbutton = (Button) sender;
            //Clicked Button Disable
            clickedbutton.Enabled = false;
            // Button Text
             letter = clickedbutton.Text;
            //Change Upper Case
            letter = letter.ToUpper();
            // Loop the array element of word
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                // if letter match with the word
                if (letter == wordToGuess[i].ToString() )
                {
                   // // The position of * for letter i is set.
                    HiddenWord[i] = letter.ToCharArray()[0];
                    txtWordToGuess.Text = string.Join(" ", HiddenWord);

                  
                    // This method is used to add score for correct option
                    LetterScore();
                    ScoreUpdate();
                  
                    GuessedCorrect = true;

                }

               
               

            }
            // If answer is false then decrease the turns left by 1
            if (GuessedCorrect == false)
            {
                GuessesLeft = GuessesLeft - 1;
           
                WrongAnswer();
                GuessedWrongTextUpdate();
                ScoreUpdate();
            }
            else
            { // Set GuessedCorrect back to False for the next round
                GuessedCorrect = false;
            }

          // If the hidden word does not have underscores left(meaning it is a complete word), the game has been won.
            if (!HiddenWord.Contains('*') )

            {
                Won();
            }

        }
 
        private void btn_Play_Game_Click(object sender, EventArgs e)
        {// Loads a new word, disable the NewGame button and set the default image


            btn_Play_Game.Enabled = false;
            LoadNewRandomWord();
            btn_Play_Game.Enabled = false;
            Load_blank_Image();
        }

      
        private void LoadNewRandomWord()
        {// Enable the A-Z buttons, set the "guesses left" to 8 and choose a random word from the wordlist and set it to uppercase and then convert that word to an array
            ButtonEnable();
            GuessesLeft = 8;
            Random randomGen = new Random();
          rand = wordList[randomGen.Next(wordList.Count)];
           rand = rand.ToUpper();
            wordToGuess = rand.ToArray();
       
 

            //  The Hiddenword char array is set to the length of the Word to Guess 
            HiddenWord = new char[wordToGuess.Length];

            // For every letter of the word, set that letter to _ 
             for (int i = 0; i < HiddenWord.Length; i++)
             {
                 HiddenWord[i] = '*';
                // And display it on the textWordToGuess, seperating the letters with a space
                txtWordToGuess.Text = string.Join(" ", HiddenWord);
             }
              
        }


        private void LoadWords()
        {

         // Open the textfile
            Stream myStream = Assets.Open("Words.txt");
            using (StreamReader sr = new StreamReader(myStream))
            {
                
                string line;
                // while the line that is being read is not equal to null (meaning there is still text to be read)
                while ((line = sr.ReadLine()) != null)
                { // Add that line to the wordlist
                    wordList.Add(line);
                }
            }
        }



        // This switch statement is based upon how many guesses the player has left
        //From 7 through to 0. Each case statement displays a different picture and runs the "GuessedWrongText" method, which just displays  a text.
        private void WrongAnswer()
        {
            switch (GuessesLeft)
            {
                case 7:
                   
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer1);
              
                    break;
                case 6:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer2);
                 
                    break;
                case 5:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer3);
                    break;

                case 4:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer4);

                    break;

                case 3:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer5);

                    break;

                case 2:
                   img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer6);

                    break;

                case 1:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer7);

                    break;

                    // Case 0 Loss Game .  
                case 0:
                    img_wrongs.SetImageResource(Resource.Drawable.WrongAnswer8);
                
                    //  12 point penalty to their score if he loss the game. If total score below 0, then final score will be 0
                    score = score - 12;
                        if(score < 0)
                        {
                            score = 0;
                        }
                    System.Threading.Thread.Sleep(200);
                    Toast.MakeText(this, "You Lose. Score was " + score, ToastLength.Short).Show();
                    var cc = new Db_Connection();
                    cc.UpdateScore(Id, PlayerName, score);
                    System.Threading.Thread.Sleep(500);


                    StartActivity(typeof(MainActivity));
                    break;
            
            }
        }

        // Code for Score
        private void LetterScore()
        {

        
            // If any of these letters are correct, their score is increased by 4
            switch (letter)
            {
                case "A":
                case "E":
                case "I":
                case "O":
                case "U":
                case "L":
                case "N":
                case "R":
                case "S":
                case "T":
                    score = score + 4;
                  // These letters increase the score by 5.. and so on
                    break;
                case "D":
                case "G":                
                case "B":
                case "C":
                case "M":
                case "P":
                    score = score + 5;
                
                    break;
                case "F":
                case "H":
                case "W":
                case "Y":
                case "V":
                    score = score +6;
                 
                    break;
                case "K":                   
                case "J":
                case "X":
                    score = score +8;
                    
                    break;
                case "Q":
                case "Z":
                     score = score + 10;
                   
                    break;
            }

            

        }


        //  Enable Buttons with options A,B,C... 
        private void ButtonEnable()
        {
            btn_A.Enabled = true;
            btn_B.Enabled = true;
            btn_C.Enabled = true;
            btn_D.Enabled = true;
            btn_E.Enabled = true;
            btn_F.Enabled = true;
            btn_G.Enabled = true;
            btn_H.Enabled = true;
            btn_I.Enabled = true;
            btn_J.Enabled = true;
            btn_K.Enabled = true;
            btn_L.Enabled = true;
            btn_M.Enabled = true;
            btn_N.Enabled = true;
            btn_O.Enabled = true;
            btn_P.Enabled = true;
            btn_Q.Enabled = true;
            btn_R.Enabled = true;
            btn_S.Enabled = true;
            btn_T.Enabled = true;
            btn_U.Enabled = true;
            btn_V.Enabled = true;
            btn_W.Enabled = true;
            btn_X.Enabled = true;
            btn_Y.Enabled = true;
            btn_Z.Enabled = true;
            btn_Play_Game.Enabled = true;
        }
             // Disable Buttons with options A,B,C...
        private void All_Disable_Buttons()
        {
            btn_A.Enabled = false;
            btn_B.Enabled = false;
            btn_C.Enabled = false;
            btn_D.Enabled = false;
            btn_E.Enabled = false;
            btn_F.Enabled = false;
            btn_G.Enabled = false;
            btn_H.Enabled = false;
            btn_I.Enabled = false;
            btn_J.Enabled = false;
            btn_K.Enabled = false;
            btn_L.Enabled = false;
            btn_M.Enabled = false;
            btn_N.Enabled = false;
            btn_O.Enabled = false;
            btn_P.Enabled = false;
            btn_Q.Enabled = false;
            btn_R.Enabled = false;
            btn_S.Enabled = false;
            btn_T.Enabled = false;
            btn_U.Enabled = false;
            btn_V.Enabled = false;
            btn_W.Enabled = false;
            btn_X.Enabled = false;
            btn_Y.Enabled = false;
            btn_Z.Enabled = false;
         
        }
       

        private void Won()
        {

            // Deafult Image
            Load_blank_Image();
            // Display Message in Text if guessed correct
            Toast.MakeText(this, "You guessed the word correctly", ToastLength.Short).
            Show();
            var cc = new Db_Connection();
            cc.UpdateScore(Id, PlayerName, score);
           // New Word
            LoadNewRandomWord();

        }


        // Method for  the wrong letter show left guess
        private void GuessedWrongTextUpdate()
        {
            txtGuessesLeft.Text = GuessesLeft.ToString();
        }


        
        private void ScoreUpdate()
        {
            txtCurrentScore.Text = score.ToString();
        }
      

        private void Load_blank_Image()
        {

            img_wrongs.SetImageResource(Resource.Drawable.blank);
        }


    }
        }
      
                 
          



       
        


        
    

