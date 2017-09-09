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
        	Assert.Fail();
        }
    }
}