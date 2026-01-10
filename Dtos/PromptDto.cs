using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiAI.Dtos
{
    public class PromptDto
    {
        public required string Prompt { get; set; }

        // public required string Model { get; set; } //definir modelos, tener en cuenta que puede variar segun servicio
    }
}