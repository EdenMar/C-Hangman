/*
 * Created by SharpDevelop.
 * User: Eden
 * Date: 2017-09-06
 * Time: 6:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
	
	public class Gameboard{
		private int limit = 7;
		private int guesses;
		private String secretWord;
		private String currentWord;
		private HashSet<char> hash = new HashSet<char>();
			
		public Gameboard(String word){
			guesses = 0;
			secretWord = word;
			StringBuilder cw = new StringBuilder();
			cw.Append(Convert.ToChar("_"), secretWord.Length);
			currentWord = cw.ToString();
		}
		
		public void printGameboard(){
			Console.Write("The word length is ");
			Console.Write(this.getSecretWordLength());
			Console.WriteLine(" letters long.");
			Console.WriteLine(currentWord.ToString());
		}
		
		public bool hasGuessesLeft(){
			return guesses < limit;
		}
		
		//take a char and replace any hits
		public void tryLetter(char c){
			if (hash.Contains(c)){
				;
			}else{
				//add the char
				hash.Add(c);
				//replace the char
				var sb = new StringBuilder();
				for (int i = 0; i < secretWord.Length; i++){
					if (secretWord[i] == c){
						sb.Append(c);
					}else{
						sb.Append(currentWord[i]);
					}
				}
				currentWord = sb.ToString();
			}
		}
		
		public String getSecretWord(){
			return secretWord;
		}
		
		public String getCurrentWord(){
			return currentWord;
		}
		
		public int getSecretWordLength(){
			return secretWord.Length;
		}

	}
	class Program
	{
		public static void Main(string[] args)
		{
			var wordList = new Dictionary<int, String>{
				{0, "apple"},
				{1, "banana"},
				{2, "cantelope"},
				{3, "durian"},
				{4, "grapefruit"},
				{5, "mango"}
			};
			Console.WriteLine("Welcome to Hangman.");
			
			Random r = new Random();
			int val = r.Next(6);
			String secret = wordList[val];
			Gameboard game = new Gameboard(secret);
			Console.WriteLine("You have 7 guesses left.");
			game.printGameboard();
			while (game.hasGuessesLeft()){
				String s = Console.ReadLine();
				char c = s[0];
			}
			Console.ReadKey();
		}
	}
}