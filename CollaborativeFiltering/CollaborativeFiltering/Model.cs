using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CollaborativeFiltering
{
    public class Model
    {
        public static string CsvFilePath { get; set; }
        public static DataTable dtInputData { get; set; }
        public static List<string> lstObjectValues { get; set; }

        //Methods--
        public static DataTable readCSV(string filePath)
        {
            var dt = new DataTable();
            // Creating the columns
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            // Adding the rows
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));
            return dt;
        }
        public static void FindTopK(int actorColumnIndex)
        {
            string objectColumnName = dtInputData.Columns[actorColumnIndex].ColumnName;
            //group the data based on initiator column index
            //var initiatorGroup = dtInputData.AsEnumerable().GroupBy(r => r.Field<string>(objectColumnName));

            //string a;
            //int b=0;
            //foreach (var group in initiatorGroup)
            //{
            //    a = group.Key;
            //    b = group.Count();
            //}

            lstObjectValues = dtInputData.AsEnumerable().Select(r => r.Field<string>(objectColumnName)).ToList();

            List<string> TrackPattern = new List<string>();

            foreach (DataRow dr in dtInputData.Rows)
            {
                string movieId = dr[1].ToString();
                string rating = dr[2].ToString();

                string pattern = movieId + "," + rating;

                if (TrackPattern.Contains(pattern)) { continue; }
                else
                {
                    TrackPattern.Add(pattern);
                    var initiatorGroup = from r in dtInputData.AsEnumerable()
                                         where r.Field<string>("MovieID") == movieId
                                         && r.Field<string>("Ratings") == rating
                                         select r.Field<string>("UserId");

                    List<string> UserAssociations = initiatorGroup.ToList();
                        

                   //dtInputData.AsEnumerable().Select(r => r.Field<string>("MovieId") == movieId & );
                }
            }

            //lstObjectValues.ForEach()
        }
    }
}
