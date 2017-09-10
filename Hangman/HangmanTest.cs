/*
 * Created by SharpDevelop.
 * User: Eden
 * Date: 2017-09-06
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using NUnit.Framework;
using Hangman;

namespace HangmanTest
{
    [TestFixture]
    public class HangmanTest
    {
        [Test]
        public void Gameboard_TestSetup()
        {
        	Gameboard g = new Gameboard("banana");
        	g.printGameboard();
        	Assert.AreEqual(g.getSecretWordLength(), 6);
        }
        
        [Test]
        public void Gameboard_TestTryLetter(){
        	Gameboard g = new Gameboard("banana");
        	Assert.AreEqual(g.getGuessesLeft(), 7);
        	g.tryLetter('a');
        	Assert.AreEqual(g.getGuessesLeft(), 6);
        	g.tryLetter('a');
        	Assert.AreEqual(g.getGuessesLeft(), 6);
        	g.tryLetter('b');
        	Assert.AreEqual(g.getCurrentWord(), "ba_a_a");
        	Assert.AreEqual(g.getGuessesLeft(), 6);
        }
        
        [Test]
        public void Gameboard_TestHasWon(){
        	Gameboard g = new Gameboard("asdf");
        	g.tryLetter('a');
        	g.tryLetter('s');
        	g.tryLetter('d');
        	g.tryLetter('f');
        	Assert.AreEqual(g.hasWon(), true);
        }
        

    }
}