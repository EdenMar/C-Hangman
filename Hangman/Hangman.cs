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
		private StringBuilder currentWord = new StringBuilder();
			
		public Gameboard(String word){
			guesses = 0;
			this.secretWord = word;
			currentWord.Append(Convert.ToChar("_"), secretWord.Length);
			
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
		
		public void tryLetter(char c){
			
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