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
using System.Linq;

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
			Console.WriteLine("You have {0} guesses left.", this.getGuessesLeft());
			Console.Write("The word length is ");
			Console.Write(this.getSecretWordLength());
			Console.WriteLine(" letters long.");
			Console.WriteLine(currentWord.ToString());
		}
		
		public int getGuessesLeft(){
			return limit-guesses;
		}
		
		public bool hasGuessesLeft(){
			return guesses < limit;
		}
		
		public bool hasWon(){
			return secretWord.Equals(currentWord);
		}
		
		//take a char and replace any hits
		public void tryLetter(char c){
			if (hash.Contains(c)){
				Console.WriteLine("Sorry, that's already been guess; try another letter.");
				return;
			}else{
				//flag to see if proposed letter in secretWord
				bool isLetter = false;
				//add the char to hash
				hash.Add(c);
				//replace the char
				var sb = new StringBuilder();
				for (int i = 0; i < secretWord.Length; i++){
					if (secretWord[i] == c){
						sb.Append(c);
						isLetter = true;
					}else{
						sb.Append(currentWord[i]);
					}
				}
				//if not a letter or a vowel, increment
				if (!isLetter || "aeiou".Contains(c)){
					guesses++;
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

			
			while (game.hasGuessesLeft() && !game.hasWon()){
				game.printGameboard();
				String s = Console.ReadLine();
				char c = s[0];
				game.tryLetter(c);

			}
	
			if (game.hasWon()){
				Console.WriteLine("You win!");
			}else{
				Console.WriteLine("Out of guesses");
			}
			
			Console.ReadKey();
		}
	}
}