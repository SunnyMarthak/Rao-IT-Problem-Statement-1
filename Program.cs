using System.Net;

int NumberOfLanes;
Dictionary<int, string> dctKeyValuePairs = new Dictionary<int, string>();
string url = "https://raw.githubusercontent.com/himesh-suthar/raocodefestv1.0/main/Traffic_Lane_Input.txt";
WebClient webClient = new WebClient();
using (Stream stream = webClient.OpenRead(url))
{
    using (StreamReader streamReader = new StreamReader(stream))
    {
        string line = streamReader.ReadLine();
        NumberOfLanes = int.Parse(line);
        int index = 1;
        while ((line = streamReader.ReadLine()) != null)
        {
            dctKeyValuePairs.Add(index++, line);
        }
    }
}
List<int> liLaneData = new List<int>();
for (int i = 1; i <= NumberOfLanes; i++)
{
    int tempSum = 0;
    int[] tempArr = dctKeyValuePairs[i].Replace("[", "").Replace("]", "").Replace(",,", ",").Split(',').Select(int.Parse).ToList().ToArray().Distinct().ToArray();
    for (int j = 0; j < tempArr.Length; j++)
    {
        tempSum += tempArr[j];
    }
    dctKeyValuePairs[i] = tempSum.ToString();
}
dctKeyValuePairs = dctKeyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
foreach (KeyValuePair<int, string> keyValuePair in dctKeyValuePairs)
{
    liLaneData.Add(keyValuePair.Key);
    liLaneData.Add(Convert.ToInt32(keyValuePair.Value));
}
Console.WriteLine("[" + string.Join(",", liLaneData) + "]");
