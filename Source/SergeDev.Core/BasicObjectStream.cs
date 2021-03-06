﻿using SergeDev.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeDev.Core
{
  public class BasicObjectStream<T> : BaseObjectStream<T>
  {
    private IEnumerator<T> source;
    private bool sourceExhausted;
    private List<T> peekQueue;

    public BasicObjectStream(IEnumerator<T> source)
    {
      this.source = source;
      this.peekQueue = new List<T>();
    }

    public override bool HasObject(int depth)
    {
      if (peekQueue.Count > depth)
      {
        return true;
      }
      else
      {
        while (QueueFromSource())
        {
          if (peekQueue.Count > depth)
            return true;
        }
        return false;
      }
    }

    public override T Peek(int depth)
    {
      return (HasObject(depth) ? peekQueue[depth] : default(T));
    }

    public override T Take()
    {
      T result = default(T);

      if (HasObject())
      {
        result = TakeUnchecked();
      }

      return result;
    }

    public override IEnumerable<T> Take(int count)
    {
      while (count-- > 0 && HasObject())
      {
        yield return TakeUnchecked();
      }
    }

    public override void Discard()
    {
      if (peekQueue.Count < 0)
        QueueFromSource();

      if (peekQueue.Count > 0)
        peekQueue.RemoveAt(0);
    }

    public override void Discard(int count)
    {
      for (var i = 0; i < count; ++i)
        Discard();
    }

    private T TakeUnchecked()
    {
      T result = peekQueue[0];
      peekQueue.RemoveAt(0);
      return result;
    }

    private bool QueueFromSource()
    {
      if (!sourceExhausted)
      {
        if (!(sourceExhausted = !source.MoveNext()))
        {
          peekQueue.Add(source.Current);
        }
      }
      return sourceExhausted;
    }
  }
}
