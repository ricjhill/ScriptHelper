﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenAI_API;
using OpenAI_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScriptHelper
{

    public partial class Form1 : Form
    {

        public OpenAIAPI api = new OpenAIAPI("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");


        List<SceneObj> scenes;
        List<SceneObj> scenesinscenes;
        SceneObj scene;

        MovieObj movie;

        string gptModel = "gpt-3.5-turbo";

        // Set up the ListBox

        public Form1()
        {
            InitializeComponent();

            SelectGPT35.Checked = true;

            // makeProtoTypeScenes();


            ScenesList.DataSource = scenes;
            SceneInScenesList.DataSource = scenesinscenes;

            ScenesList.DisplayMember = "Title";

            MovieHintText.Text = makePrototypeMovieHint();

            Movie.SelectedIndexChanged += Movie_SelectedIndexChanged;

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Movie_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                int selectedIndex = tabControl.SelectedIndex;
                if (selectedIndex == 1)
                {

                    SceneInScenesList.DataSource = scenes;
                    SceneInScenesList.DisplayMember = "Title";
                    Application.DoEvents();

                    int picked = SceneInScenesList.SelectedIndex;
                    SceneHint.Text = scenes[picked].Description;
                    Application.DoEvents();

                }
                // Perform your desired actions based on the selected index.
                // MessageBox.Show($"Selected tab index: {selectedIndex}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void MovieHintText_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        

        private async void Button1_Click_1(object sender, EventArgs e)
        {

            MovieText.Text = MovieHintText.Text + "\n \n " + gptModel + " awaiting reply...";
            string reply = await MyGPT.makeMovieText(api, MovieHintText.Text, gptModel);
            MovieText.Text = reply;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MovieObj movie = new MovieObj();
            MovieHintText.Text = movie.movieHintText;
        }

        private void SelectGPT35_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectGPT35.Checked)
            {
                gptModel = "gpt-3.5-turbo";
                SelectGPT4.Checked = false;

            }

        }

        private void SelectGPT4_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectGPT4.Checked)
            {
                gptModel = "gpt-4";
                SelectGPT35.Checked = false;
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            MovieTextCompiled.Text = Utils.makePendingMessage(gptModel);

            string reply = await MyGPT.makeMovieCompiledText(api, MovieText.Text, gptModel);

            MovieTextCompiled.Text = "model: " + gptModel + "\n" + reply;


        }
 
        private string makePrototypeMovieHint()
        {
            string hint = @"a 19 year old man <Robert> meets a 39 year old married woman <Beth>, and they both fall in love.
 A passionate affair ensues, which ends tragically when her husband <Oscar> kills them both";
            return hint;
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            if (MovieText.Text.Length < 50)
                { MessageBox.Show("Not Enough Movie Text.  Need at least 50 characters "); }

            else
            {
                SceneDescriptions.Clear();
                SceneDescriptions.Text = Utils.makePendingMessage(gptModel);
                SceneDescriptions.Text  =  await MyGPT.makeScenesFromMovieText(api, MovieText.Text, gptModel, (int)SceneCount.Value);
                // var ListofList = JsonConvert.DeserializeObject(SceneDescriptions.Text);
                var listOfLists = JsonConvert.DeserializeObject<List<List<string>>>(SceneDescriptions.Text);

                scenes = new List<SceneObj>();
                foreach (List<string> myScene in listOfLists)
                {

                    SceneObj scene = new SceneObj();
                    string myTitle = myScene[0];
                    string myDescription = myScene[1];
                    scene.Title = myTitle;
                    scene.Description = myDescription;
                    scenes.Add(scene);
                }
                ScenesList.DataSource = scenes;
                ScenesList.DisplayMember = "Title";


            }


        }

        private void SceneInScenesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int picked = SceneInScenesList.SelectedIndex;
            SceneHint.Text = scenes[picked].Description;
            Application.DoEvents();
        }

        private void SceneHint_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            
            SceneText.Text = SceneHint.Text + "  >> " + gptModel + " awaiting reply...";
            string reply =   await MyGPT.makeSceneText(api, SceneHint.Text, gptModel);
            SceneText.Text = reply;

            
        }
    }
}
