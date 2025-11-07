class Human(string pName, int pAge, string pProfession, string pStartingLocation, int pSpeed, int pDefaultHealth) {
	public string Name = pName;
	private string Age = pAge;
	private string Profession = pProfession;
	private string StartingLocation = pStartingLocation;
	private int Money = 0;
	private int Speed = pSpeed;
	private int Health = pDefaultHealth;

	public void Dialogue(string Dialogue) {
		Console.WriteLine("${Name} says  {Dialogue}")
	}
	
}
