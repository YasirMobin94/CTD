namespace CTD.Helpers
{
    public class CommonHelper
    {
        private static Dictionary<string, string> ukCitiesDict = null;
        public static Dictionary<string, string> UKCitiesDictionary()
        {
            if (ukCitiesDict is null)
            {
                ukCitiesDict = new()
                {
                    { "London", "london" },
                    { "Birmingham", "birmingham" },
                    { "Glasgow", "glasgow" },
                    { "Leeds", "leeds" },
                    { "Manchester", "manchester" },
                    { "Edinburgh", "edinburgh" },
                    { "Bristol", "bristol" },
                    { "Liverpool", "liverpool" },
                    { "Newcastle", "newcastle-upon-tyne" },
                    { "Sheffield", "sheffield" },
                    { "Cardiff", "cardiff" },
                    { "Belfast", "belfast" },
                    { "Nottingham", "nottingham" },
                    { "Southampton", "southampton" },
                    { "Leicester", "leicester" },
                    { "Brighton", "brighton-and-hove" },
                    { "Stoke-on-Trent", "stoke-on-trent" },
                    { "Wolver", "wolverhampton" },
                    { "Plymouth", "plymouth" },
                    { "Hull", "hull" },
                    { "Derby", "derby" },
                    { "Swansea", "swansea" },
                    { "Salford", "salford" },
                    { "Aberdeen", "aberdeen" },
                    { "Westminster", "westminster" },
                    { "Portsmouth", "portsmouth" },
                    { "York", "york" },
                    { "Peterborough", "peterborough" },
                    { "Dundee", "dundee" },
                    { "Lancaster", "lancaster" },
                    { "Oxford", "oxford" },
                    { "Newport", "newport" },
                    { "Preston", "preston" },
                    { "St Albans", "st-albans" },
                    { "Norwich", "norwich" },
                    { "Chester", "chester" },
                    { "Cambridge", "cambridge" },
                    { "Salisbury", "salisbury" },
                    { "Exeter", "exeter" },
                    { "Gloucester", "gloucester" },
                    { "Lisburn", "lisburn" },
                    { "Chichester", "chichester" },
                    { "Winchester", "winchester" },
                    { "Londonderry", "londonderry" },
                    { "Carlisle", "carlisle" },
                    { "Worcester", "worcester" },
                    { "Bath", "bath" },
                    { "Durham", "durham" },
                    { "Lincoln", "lincoln" },
                    { "Hereford", "hereford" },
                    { "Armagh", "armagh" },
                    { "Inverness", "inverness" },
                    { "Stirling", "stirling" },
                    { "Canterbury", "canterbury" },
                    { "Lichfield", "lichfield" },
                    { "Newry", "newry" },
                    { "Ripon", "ripon" },
                    { "Bangor", "bangor" },
                    { "Truro", "truro" },
                    { "Ely", "ely" },
                    { "Wells", "wells" },
                    { "St. Davids", "st-davids" },
                    { "Perth", "perth" },
                    { "St. Asaph", "st-asaph" },
                    { "St. Andrews", "st-andrews" },
                    { "Wakefield", "wakefield" }
                };
                ukCitiesDict = ukCitiesDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
            return ukCitiesDict;
        }
    }
}
