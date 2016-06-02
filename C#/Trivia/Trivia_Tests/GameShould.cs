using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;
using Trivia;

namespace Trivia_Tests
{
    [TestFixture]
    public class Le_jeu_devrait
    {
        [Test]
        public void NUnitIsWorking()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void se_terminer_apres_6_bonnes_reponses_d_un_joueur_quand_il_faut_6_points_pour_gagner()
        {
            // Arrange
            var le_jeu = new Game();
            le_jeu.add("toto");

            // Action
            le_jeu.wasCorrectlyAnswered();
            le_jeu.wasCorrectlyAnswered();
            le_jeu.wasCorrectlyAnswered();
            le_jeu.wasCorrectlyAnswered();
            le_jeu.wasCorrectlyAnswered();
            var se_terminer_apres_6_bonnes_reponses_d_un_joueur = !le_jeu.wasCorrectlyAnswered();

            // Asserts
            Assert.IsTrue(se_terminer_apres_6_bonnes_reponses_d_un_joueur);
        }

        [Test]
        public void se_terminer_apres_2_bonnes_reponses_d_un_joueur_quand_il_faut_2_points_pour_gagner()
        {
            // Arrange
            var le_jeu = new Game(2);
            le_jeu.add("toto");

            // Action
            le_jeu.wasCorrectlyAnswered();
            var se_terminer_apres_2_bonnes_reponses_d_un_joueur = !le_jeu.wasCorrectlyAnswered();

            // Asserts
            Assert.IsTrue(se_terminer_apres_2_bonnes_reponses_d_un_joueur);
        }

        [Test]
        public void avoir_les_4_catégories_par_défaut()
        {
            // Arrange
            var le_jeu = new Game();
            le_jeu.add("toto");

            var previousOut = Console.Out;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Action
            le_jeu.roll(1);
            le_jeu.roll(1);
            le_jeu.roll(1);
            le_jeu.roll(1);

            Console.SetOut(previousOut);

            // Asserts
            Check.That(stringWriter.ToString()).Contains("Science", "Pop", "Sports", "Rock");
        }

        [Test]
        public void pouvoir_avoir_3_catégories()
        {
            // Arrange
            var questions = new Questions(new[] { "Animaux", "Voiture", "Immobilier" });

            var le_jeu = new Game(6, questions);
            le_jeu.add("toto");
            var previousOut = Console.Out;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            le_jeu.roll(1);
            le_jeu.roll(1);
            le_jeu.roll(1);

            Console.SetOut(previousOut);

            // Asserts
            Check.That(stringWriter.ToString()).Contains("Animaux", "Voiture", "Immobilier");
        }
    }
}
