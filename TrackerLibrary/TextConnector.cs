using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        //TODO - Wire Up the CreatePrize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;

            return model;
        }
    }
}

//Text Connection
