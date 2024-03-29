﻿using System.Collections.Generic;

using Suls.ViewModels.Submissions;

namespace Suls.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
