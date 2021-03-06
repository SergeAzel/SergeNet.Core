﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Language.Syntax.Tokens
{
  public class WhitespaceToken : IToken
  {
    private string value;
    public WhitespaceToken(string value)
    {
      this.value = value;
    }

    public string Value
    {
      get { return value; }
    }

    public bool Critical
    {
      get { return false; }
    }
  }
}
