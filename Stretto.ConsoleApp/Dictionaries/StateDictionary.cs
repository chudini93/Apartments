using System;
using System.Collections.Generic;
using System.Linq;

namespace Stretto.ConsoleApp.Dictionaries
{
    public static class StatesDictionary
    {
        public static readonly IEnumerable<KeyValuePair<string, string>> States = new KeyValuePair<string, string>[]
        {
            new KeyValuePair<string, string>("AL", "ALABAMA"),
            new KeyValuePair<string, string>("AK", "ALASKA"),
            new KeyValuePair<string, string>("AS", "AMERICAN SAMOA"),
            new KeyValuePair<string, string>("AZ", "ARIZONA"),
            new KeyValuePair<string, string>("AR", "ARKANSAS"),
            new KeyValuePair<string, string>("CA", "CALIFORNIA"),
            new KeyValuePair<string, string>("CO", "COLORADO"),
            new KeyValuePair<string, string>("CT", "CONNECTICUT"),
            new KeyValuePair<string, string>("DE", "DELAWARE"),
            new KeyValuePair<string, string>("DC", "DISTRICT OF COLUMBIA"),
            new KeyValuePair<string, string>("FL", "FLORIDA"),
            new KeyValuePair<string, string>("GA", "GEORGIA"),
            new KeyValuePair<string, string>("GU", "GUAM"),
            new KeyValuePair<string, string>("HI", "HAWAII"),
            new KeyValuePair<string, string>("ID", "IDAHO"),
            new KeyValuePair<string, string>("IL", "ILLINOIS"),
            new KeyValuePair<string, string>("IN", "INDIANA"),
            new KeyValuePair<string, string>("IA", "IOWA"),
            new KeyValuePair<string, string>("KS", "KANSAS"),
            new KeyValuePair<string, string>("KY", "KENTUCKY"),
            new KeyValuePair<string, string>("LA", "LOUISIANA"),
            new KeyValuePair<string, string>("ME", "MAINE"),
            new KeyValuePair<string, string>("MD", "MARYLAND"),
            new KeyValuePair<string, string>("MA", "MASSACHUSETTS"),
            new KeyValuePair<string, string>("MI", "MICHIGAN"),
            new KeyValuePair<string, string>("MN", "MINNESOTA"),
            new KeyValuePair<string, string>("MS", "MISSISSIPPI"),
            new KeyValuePair<string, string>("MO", "MISSOURI"),
            new KeyValuePair<string, string>("MT", "MONTANA"),
            new KeyValuePair<string, string>("NE", "NEBRASKA"),
            new KeyValuePair<string, string>("NV", "NEVADA"),
            new KeyValuePair<string, string>("NH", "NEW HAMPSHIRE"),
            new KeyValuePair<string, string>("NJ", "NEW JERSEY"),
            new KeyValuePair<string, string>("NM", "NEW MEXICO"),
            new KeyValuePair<string, string>("NY", "NEW YORK"),
            new KeyValuePair<string, string>("NC", "NORTH CAROLINA"),
            new KeyValuePair<string, string>("ND", "NORTH DAKOTA"),
            new KeyValuePair<string, string>("MP", "NORTHERN MARIANA IS"),
            new KeyValuePair<string, string>("OH", "OHIO"),
            new KeyValuePair<string, string>("OK", "OKLAHOMA"),
            new KeyValuePair<string, string>("OR", "OREGON"),
            new KeyValuePair<string, string>("PA", "PENNSYLVANIA"),
            new KeyValuePair<string, string>("PR", "PUERTO RICO"),
            new KeyValuePair<string, string>("RI", "RHODE ISLAND"),
            new KeyValuePair<string, string>("SC", "SOUTH CAROLINA"),
            new KeyValuePair<string, string>("SD", "SOUTH DAKOTA"),
            new KeyValuePair<string, string>("TN", "TENNESSEE"),
            new KeyValuePair<string, string>("TX", "TEXAS"),
            new KeyValuePair<string, string>("UT", "UTAH"),
            new KeyValuePair<string, string>("VT", "VERMONT"),
            new KeyValuePair<string, string>("VA", "VIRGINIA"),
            new KeyValuePair<string, string>("VI", "VIRGIN ISLANDS"),
            new KeyValuePair<string, string>("WA", "WASHINGTON"),
            new KeyValuePair<string, string>("WV", "WEST VIRGINIA"),
            new KeyValuePair<string, string>("WI", "WISCONSIN"),
            new KeyValuePair<string, string>("WY", "WYOMING")
        };

        public static string GetStateByAbbreviation(string value)
        {
            var state = States.FirstOrDefault(x => string.Equals(x.Key, value, StringComparison.CurrentCultureIgnoreCase));
            if (!state.Equals(default(KeyValuePair<string, string>)))
            {
                return state.Value;
            }

            return null;
        }

        public static string GetStateByName(string value)
        {
            var state = States.FirstOrDefault(x => string.Equals(x.Key, value, StringComparison.CurrentCultureIgnoreCase));
            if (!state.Equals(default(KeyValuePair<string, string>)))
            {
                return state.Value;
            }

            return null;
        }

        public static string GetStateByNameOrAbbreviation(string value)
        {
            string state = GetStateByAbbreviation(value);
            if (string.IsNullOrEmpty(state))
            {
                state = GetStateByName(value);
            }

            return state;
        }
    }
}
