using MarsRover.Topologie;

namespace MarsRover.Ui.Test
{
    public class UiTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Affichage_Taille_N(int taille)
        {
            // ETANT DONNE une planète de taille n
            var planète = new PlanèteToroïdale(taille);

            // QUAND on la représente
            var representation = new Carte(planète).ToString();

            // ALORS on obtient N lignes de N colonnes
            var ligneAttendue = string.Concat(Enumerable.Repeat(Symboles.CaseDécouverteLibre, taille)) + Environment.NewLine;
            var blocAttendu = string.Concat(Enumerable.Repeat(ligneAttendue, taille));

            Assert.Equal(blocAttendu, representation);
        }

        [Fact]
        public void AffichageObstacleSeul()
        {
            // ETANT DONNE une planète de taille 1
            // ET un obstacle sur sa seule case
            var planète = new PlanèteToroïdale(1)
                .AjouterObstacle(new Obstacle(0, 0));

            // QUAND on la représente
            var representation = new Carte(planète).ToString();

            // ALORS on obtient le symbole obstacle seul
            var attendu = Symboles.CaseDécouverteObstacle + Environment.NewLine;
            Assert.Equal(attendu, representation);
        }

        public static IEnumerable<object[]> CasAffichageRoverSeul()
        {
            yield return [Orientation.Nord, Symboles.CaseRoverNord];
            yield return [Orientation.Est, Symboles.CaseRoverEst];
            yield return [Orientation.Sud, Symboles.CaseRoverSud];
            yield return [Orientation.Ouest, Symboles.CaseRoverOuest];
        }

        [Theory]
        [MemberData(nameof(CasAffichageRoverSeul))]
        public void AffichageRoverSeul(Orientation orientation, char symboleAttendu)
        {
            // ETANT DONNE une planète de taille 1
            // ET un rover orienté nord sur sa seule case
            var planète = new PlanèteToroïdale(1);
            var rover = new Rover.Rover(orientation, planète);

            // QUAND on les représente
            var representation = new Carte(planète).Représenter(rover).ToString();

            // ALORS on obtient le symbole rover seul
            var attendu = symboleAttendu + Environment.NewLine;
            Assert.Equal(attendu, representation);
        }

        [Fact]
        public void AffichageRoverSeulTaille2Zero()
        {
            // ETANT DONNE une planète de taille 2
            // ET un rover orienté nord en 1,1
            var planète = new PlanèteToroïdale(2);
            var rover = new Rover.Rover(Orientation.Nord, planète, 0, 0);

            // QUAND on les représente
            var representation = new Carte(planète).Représenter(rover).ToString();

            // ALORS on obtient le symbole rover en haut à droite
            var attendu = Symboles.CaseDécouverteLibre + "" + Symboles.CaseDécouverteLibre + Environment.NewLine + 
                          Symboles.CaseRoverNord + "" + Symboles.CaseDécouverteLibre + Environment.NewLine;

            Assert.Equal(attendu, representation);
        }

        [Theory]
        [MemberData(nameof(CasAffichageRoverSeul))]
        public void AffichageRoverSeulTaille2(Orientation orientation, char symboleAttendu)
        {
            // ETANT DONNE une planète de taille 2
            // ET un rover orienté nord en 1,1
            var planète = new PlanèteToroïdale(2);
            var rover = new Rover.Rover(orientation, planète, 1, 1);

            // QUAND on les représente
            var representation = new Carte(planète).Représenter(rover).ToString();

            // ALORS on obtient le symbole rover en haut à droite
            var attendu = Symboles.CaseDécouverteLibre + "" + symboleAttendu + Environment.NewLine + 
                          Symboles.CaseDécouverteLibre + "" + Symboles.CaseDécouverteLibre + Environment.NewLine;

            Assert.Equal(attendu, representation);
        }

        [Fact]
        public void AffichageObstacleSurTaille2()
        {
            // ETANT DONNE une planète de taille 2
            // ET un obstacle en 1,1
            var planète = new PlanèteToroïdale(2)
                .AjouterObstacle(new Obstacle(1, 1));

            // QUAND on la représente
            var representation = new Carte(planète).ToString();

            // ALORS on obtient le symbole obstacle seul entouré de 3 cases vides
            var attendu = 
                Symboles.CaseDécouverteLibre + "" + Symboles.CaseDécouverteObstacle + Environment.NewLine +
                Symboles.CaseDécouverteLibre + "" + Symboles.CaseDécouverteLibre + Environment.NewLine;

            Assert.Equal(attendu, representation);
        }

        [Fact]
        public void Affichage2ObstacleSurTaille2()
        {
            // ETANT DONNE une planète de taille 2
            // ET un obstacle en 0,0
            // ET un obstacle en 1,1
            var planète = new PlanèteToroïdale(2)
                .AjouterObstacle(new Obstacle(0, 0))
                .AjouterObstacle(new Obstacle(1, 1));

            // QUAND on la représente
            var representation = new Carte(planète).ToString();

            // ALORS on obtient le symbole obstacle seul entouré de 3 cases vides
            var attendu = 
                Symboles.CaseDécouverteLibre + "" + Symboles.CaseDécouverteObstacle + Environment.NewLine +
                Symboles.CaseDécouverteObstacle + "" + Symboles.CaseDécouverteLibre + Environment.NewLine;

            Assert.Equal(attendu, representation);
        }
    }
}