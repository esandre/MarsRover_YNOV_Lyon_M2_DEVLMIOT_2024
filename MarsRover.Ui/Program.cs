using System.Text;
using MarsRover.Rover;
using MarsRover.Topologie;
using MarsRover.Ui;

Console.OutputEncoding = Encoding.UTF8;

var planète = new PlanèteToroïdale(8)
    .AjouterObstacle(new Obstacle(2,4))
    .AjouterObstacle(new Obstacle(1,0))
    .AjouterObstacle(new Obstacle(7,4))
    .AjouterObstacle(new Obstacle(3,3));

IRover rover = new Rover(Orientation.Est, planète, 1, 1);

while (true)
{
    Console.SetCursorPosition(0, 0);

    var carte = new Carte(planète)
        .Représenter(rover);

    Console.Write(carte);

    var key = Console.ReadKey().KeyChar;
    var command = key.ToString().ToUpperInvariant().Single();

    rover = rover.Recevoir(command);
}

