using Nancy;
using CSharpWarrior.Domain;

namespace CSharpWarrior.Web
{
    public class LevelResponse
	{
        public Tile[] Tiles { get; set; }
        public string Objective { get; set; }
	}

}
