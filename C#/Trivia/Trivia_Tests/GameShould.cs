using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UglyTrivia;

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
    }
}
