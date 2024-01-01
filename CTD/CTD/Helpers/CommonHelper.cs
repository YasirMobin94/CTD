using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                    {"Aberdeen", "aberdeen"},
                    {"Armagh", "armagh"},
                    {"Bangor", "bangor"},
                    {"Bath", "bath"},
                    {"Belfast", "belfast"},
                    {"Birmingham", "birmingham"},
                    {"Bradford", "bradford"},
                    {"Brighton", "brighton-and-hove"},
                    {"Bristol", "bristol"},
                    {"Cambridge", "cambridge"},
                    {"Canterbury", "canterbury"},
                    {"Cardiff", "cardiff"},
                    {"Carlisle", "carlisle"},
                    {"Chelmsford", "chelmsford"},
                    {"Chester", "chester"},
                    {"Chichester", "chichester"},
                    {"Colchester", "colchester"},
                    {"Coventry", "coventry"},
                    {"Derby", "derby"},
                    {"Doncaster", "doncaster"},
                    {"Dundee", "dundee"},
                    {"Dunfermline", "dunfermline"},
                    {"Durham", "durham"},
                    {"Edinburgh", "edinburgh"},
                    {"Ely", "ely"},
                    {"Exeter", "exeter"},
                    {"Glasgow", "glasgow"},
                    {"Gloucester", "gloucester"},
                    {"Hereford", "hereford"},
                    {"Inverness", "inverness"},
                    {"Kingston", "kingston-upon-hull"},
                    {"Lancaster", "lancaster"},
                    {"Leeds", "leeds"},
                    {"Leicester", "leicester"},
                    {"Lichfield", "lichfield"},
                    {"Lincoln", "lincoln"},
                    {"Lisburn", "lisburn"},
                    {"Liverpool", "liverpool"},
                    {"London", "london"},
                    {"Londonderry", "londonderry"},
                    {"Manchester", "manchester"},
                    {"Milton Keynes", "milton-keynes"},
                    {"Newcastle", "newcastle-upon-tyne"},
                    {"Newport", "newport"},
                    {"Newry", "newry"},
                    {"Norwich", "norwich"},
                    {"Nottingham", "nottingham"},
                    {"Oxford", "oxford"},
                    {"Perth", "perth"},
                    {"Peterborough", "peterborough"},
                    {"Plymouth", "plymouth"},
                    {"Portsmouth", "portsmouth"},
                    {"Preston", "preston"},
                    {"Ripon", "ripon"},
                    {"Salford", "salford"},
                    {"Salisbury", "salisbury"},
                    {"Sheffield", "sheffield"},
                    {"Southampton", "southampton"},
                    {"Southend", "southend-on-sea"},
                    {"St Albans", "st-albans"},
                    {"St Asaph", "st-asaph-llanelwy"},
                    {"St Davids", "st-davids"},
                    {"Stirling", "stirling"},
                    {"Stoke on Trent", "stoke-on-trent"},
                    {"Sunderland", "sunderland"},
                    {"Swansea", "swansea"},
                    {"Truro", "truro"},
                    {"Wakefield", "wakefield"},
                    {"Wells", "wells"},
                    {"Westminster", "westminster"},
                    {"Winchester", "winchester"},
                    {"Wolver", "wolverhampton"},
                    {"Worcester", "worcester"},
                    {"Wrexham", "wrexham"},
                    {"York", "york" }
                };
                ukCitiesDict = ukCitiesDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
            return ukCitiesDict;
        }

        public static List<string> GetModelErrros(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.Where(E => E.Errors.Count > 0)
                         .SelectMany(E => E.Errors)
                         .Select(E => E.ErrorMessage)
                         .ToList();

            return errors;
        }
    }
}
