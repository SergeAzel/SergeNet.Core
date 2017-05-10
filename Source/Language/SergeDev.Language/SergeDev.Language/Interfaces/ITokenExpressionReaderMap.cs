﻿using SergeDev.Contracts.Interfaces;
using SergeDev.Language.Core.Interfaces;
using SergeDev.Language.Syntax.Expressions;
using SergeDev.Language.Syntax.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Interfaces
{
  public interface ITokenExpressionReaderMap<T> : IReaderMap<BaseToken, T> where T : BaseExpression
  {
  }
}