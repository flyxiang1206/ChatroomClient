using System;
using System.Collections.Generic;
using System.Text;

namespace ChatroomClient
{
    public interface IBasicData<T> where T : class
    {
        byte[] ToBytes();

        T FromBytes(byte[] bytes);
    }
}
