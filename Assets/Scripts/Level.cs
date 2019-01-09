public struct Level	{
	public float timeLimit;
	public int totalEnemiesToSpawn;
	public int peoplePersonsToSpawn;
	public int policePersonsToSpawn;
	public int riotPersonsToSpawn;

	public Level (float time, int peopleToSpawn, int policeToSpawn, int riotToSpawn)
	{
		timeLimit = time;
		peoplePersonsToSpawn = peopleToSpawn;
		policePersonsToSpawn = policeToSpawn;
		riotPersonsToSpawn = riotToSpawn;
		totalEnemiesToSpawn = peoplePersonsToSpawn + policePersonsToSpawn + riotPersonsToSpawn;
	}
}