using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class DatafileOption
	{
		public string DatafileName { get; set; }
		public string DatafilePath { get; set; }
		public string DatafileSize { get; set; }
		public string Autoextend { get; set; }
		public string AutoextendSize { get; set; }
		public string Maxsize { get; set; }

		public DatafileOption(string datafileName, string datafilePath, string datafileSize, string autoextend, string autoextendSize, string maxsize)
		{
			DatafileName = datafileName;
			DatafilePath = datafilePath;
			DatafileSize = datafileSize;
			Autoextend = autoextend;
			AutoextendSize = autoextendSize;
			Maxsize = maxsize;
		}

		public DatafileOption()
		{

		}
	}

}
