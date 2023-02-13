using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Types
{
    internal class ServiceResponse<TResult>
    {
        private Dictionary<string, List<string>> _errors;

        public bool IsValid => !_errors.Any();

        public Dictionary<string, List<string>> Errors => _errors;

    }
}
