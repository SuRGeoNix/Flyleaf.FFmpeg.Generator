namespace Flyleaf.FFmpeg;

public unsafe struct AVRational_array2
{
    public const int Size = 2;
    public AVRational _0, _1;
    
    public AVRational this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational[] ToArray() => new [] { _0, _1 };
    
    public void UpdateFrom(AVRational[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational* p = array)
        {
            _0 = p[0];
            _1 = p[1];
        }
    }
}

public unsafe struct short_array2
{
    public const int Size = 2;
    public fixed short _[2];
    
    public short this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public short[] ToArray() => new [] { _[0], _[1] };
    
    
    public void UpdateFrom(short[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (short* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
        }
    }
}

public unsafe struct void_ptrArray2
{
    public const int Size = 2;
    /// <summary>original type: void*</summary>
    public IntPtr _0, _1;
    
    /// <summary>original type: void*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public void*[] ToRawArray() => new [] { (void*)_0, (void*)_1 };
    
    /// <summary>original type: void*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1 };
    
    /// <summary>original type: void*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
        }
    }
}

public unsafe struct AVHDRPlusColorTransformParams_array3
{
    public const int Size = 3;
    public AVHDRPlusColorTransformParams _0, _1, _2;
    
    public AVHDRPlusColorTransformParams this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVHDRPlusColorTransformParams* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVHDRPlusColorTransformParams* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVHDRPlusColorTransformParams[] ToArray() => new [] { _0, _1, _2 };
    
    public void UpdateFrom(AVHDRPlusColorTransformParams[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVHDRPlusColorTransformParams* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
        }
    }
}

public unsafe struct AVRational_array3
{
    public const int Size = 3;
    public AVRational _0, _1, _2;
    
    public AVRational this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational[] ToArray() => new [] { _0, _1, _2 };
    
    public void UpdateFrom(AVRational[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
        }
    }
}

public unsafe struct AVRational_array3x2
{
    public const int Size = 3;
    public AVRational_array2 _0, _1, _2;
    
    public AVRational_array2 this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational_array2* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational_array2* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational_array2[] ToArray() => new [] { _0, _1, _2 };
    
    public void UpdateFrom(AVRational_array2[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational_array2* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
        }
    }
}

public unsafe struct byte_ptrArray3
{
    public const int Size = 3;
    /// <summary>original type: byte*</summary>
    public IntPtr _0, _1, _2;
    
    /// <summary>original type: byte*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public byte*[] ToRawArray() => new [] { (byte*)_0, (byte*)_1, (byte*)_2 };
    
    /// <summary>original type: byte*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1, _2 };
    
    /// <summary>original type: byte*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
        }
    }
}

public unsafe struct int_array3
{
    public const int Size = 3;
    public fixed int _[3];
    
    public int this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public int[] ToArray() => new [] { _[0], _[1], _[2] };
    
    
    public void UpdateFrom(int[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (int* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
        }
    }
}

public unsafe struct short_array3x2
{
    public const int Size = 3;
    public short_array2 _0, _1, _2;
    
    public short_array2 this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (short_array2* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (short_array2* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public short_array2[] ToArray() => new [] { _0, _1, _2 };
    
    public void UpdateFrom(short_array2[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (short_array2* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
        }
    }
}

public unsafe struct AVComponentDescriptor_array4
{
    public const int Size = 4;
    public AVComponentDescriptor _0, _1, _2, _3;
    
    public AVComponentDescriptor this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVComponentDescriptor* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVComponentDescriptor* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVComponentDescriptor[] ToArray() => new [] { _0, _1, _2, _3 };
    
    public void UpdateFrom(AVComponentDescriptor[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVComponentDescriptor* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
        }
    }
}

public unsafe struct byte_array4
{
    public const int Size = 4;
    public fixed byte _[4];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
        }
    }
}

public unsafe struct byte_ptrArray4
{
    public const int Size = 4;
    /// <summary>original type: byte*</summary>
    public IntPtr _0, _1, _2, _3;
    
    /// <summary>original type: byte*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public byte*[] ToRawArray() => new [] { (byte*)_0, (byte*)_1, (byte*)_2, (byte*)_3 };
    
    /// <summary>original type: byte*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1, _2, _3 };
    
    /// <summary>original type: byte*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
        }
    }
}

public unsafe struct int_array4
{
    public const int Size = 4;
    public fixed int _[4];
    
    public int this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public int[] ToArray() => new [] { _[0], _[1], _[2], _[3] };
    
    
    public void UpdateFrom(int[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (int* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
        }
    }
}

public unsafe struct long_array4
{
    public const int Size = 4;
    public fixed long _[4];
    
    public long this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public long[] ToArray() => new [] { _[0], _[1], _[2], _[3] };
    
    
    public void UpdateFrom(long[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (long* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
        }
    }
}

public unsafe struct nint_array4
{
    public const int Size = 4;
    public nint _0, _1, _2, _3;
    
    public nint this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (nint* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (nint* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public nint[] ToArray() => new [] { _0, _1, _2, _3 };
    
    public void UpdateFrom(nint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (nint* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
        }
    }
}

public unsafe struct nuint_array4
{
    public const int Size = 4;
    public nuint _0, _1, _2, _3;
    
    public nuint this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (nuint* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (nuint* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public nuint[] ToArray() => new [] { _0, _1, _2, _3 };
    
    public void UpdateFrom(nuint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (nuint* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
        }
    }
}

public unsafe struct uint_array4
{
    public const int Size = 4;
    public fixed uint _[4];
    
    public uint this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public uint[] ToArray() => new [] { _[0], _[1], _[2], _[3] };
    
    
    public void UpdateFrom(uint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (uint* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
        }
    }
}

public unsafe struct int_array7
{
    public const int Size = 7;
    public fixed int _[7];
    
    public int this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public int[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6] };
    
    
    public void UpdateFrom(int[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (int* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
        }
    }
}

public unsafe struct AVBufferRef_ptrArray8
{
    public const int Size = 8;
    /// <summary>original type: AVBufferRef*</summary>
    public IntPtr _0, _1, _2, _3, _4, _5, _6, _7;
    
    /// <summary>original type: AVBufferRef*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVBufferRef*[] ToRawArray() => new [] { (AVBufferRef*)_0, (AVBufferRef*)_1, (AVBufferRef*)_2, (AVBufferRef*)_3, (AVBufferRef*)_4, (AVBufferRef*)_5, (AVBufferRef*)_6, (AVBufferRef*)_7 };
    
    /// <summary>original type: AVBufferRef*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7 };
    
    /// <summary>original type: AVBufferRef*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
        }
    }
}

public unsafe struct byte_ptrArray8
{
    public const int Size = 8;
    /// <summary>original type: byte*</summary>
    public IntPtr _0, _1, _2, _3, _4, _5, _6, _7;
    
    /// <summary>original type: byte*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public byte*[] ToRawArray() => new [] { (byte*)_0, (byte*)_1, (byte*)_2, (byte*)_3, (byte*)_4, (byte*)_5, (byte*)_6, (byte*)_7 };
    
    /// <summary>original type: byte*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7 };
    
    /// <summary>original type: byte*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
        }
    }
}

public unsafe struct int_array8
{
    public const int Size = 8;
    public fixed int _[8];
    
    public int this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public int[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7] };
    
    
    public void UpdateFrom(int[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (int* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
        }
    }
}

public unsafe struct nint_array8
{
    public const int Size = 8;
    public nint _0, _1, _2, _3, _4, _5, _6, _7;
    
    public nint this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (nint* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (nint* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public nint[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7 };
    
    public void UpdateFrom(nint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (nint* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
        }
    }
}

public unsafe struct nuint_array8
{
    public const int Size = 8;
    public nuint _0, _1, _2, _3, _4, _5, _6, _7;
    
    public nuint this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (nuint* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (nuint* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public nuint[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7 };
    
    public void UpdateFrom(nuint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (nuint* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
        }
    }
}

public unsafe struct uint_array8
{
    public const int Size = 8;
    public fixed uint _[8];
    
    public uint this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public uint[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7] };
    
    
    public void UpdateFrom(uint[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (uint* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
        }
    }
}

public unsafe struct ulong_array8
{
    public const int Size = 8;
    public fixed ulong _[8];
    
    public ulong this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public ulong[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7] };
    
    
    public void UpdateFrom(ulong[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (ulong* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
        }
    }
}

public unsafe struct void_ptrArray8
{
    public const int Size = 8;
    /// <summary>original type: void*</summary>
    public IntPtr _0, _1, _2, _3, _4, _5, _6, _7;
    
    /// <summary>original type: void*</summary>
    public IntPtr this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (IntPtr* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (IntPtr* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public void*[] ToRawArray() => new [] { (void*)_0, (void*)_1, (void*)_2, (void*)_3, (void*)_4, (void*)_5, (void*)_6, (void*)_7 };
    
    /// <summary>original type: void*</summary>
    public IntPtr[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7 };
    
    /// <summary>original type: void*</summary>
    public void UpdateFrom(IntPtr[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (IntPtr* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
        }
    }
}

public unsafe struct int_array9
{
    public const int Size = 9;
    public fixed int _[9];
    
    public int this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public int[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8] };
    
    
    public void UpdateFrom(int[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (int* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
        }
    }
}

public unsafe struct byte_array10
{
    public const int Size = 10;
    public fixed byte _[10];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
        }
    }
}

public unsafe struct AVHDRPlusPercentile_array15
{
    public const int Size = 15;
    public AVHDRPlusPercentile _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14;
    
    public AVHDRPlusPercentile this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVHDRPlusPercentile* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVHDRPlusPercentile* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVHDRPlusPercentile[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14 };
    
    public void UpdateFrom(AVHDRPlusPercentile[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVHDRPlusPercentile* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
            _8 = p[8];
            _9 = p[9];
            _10 = p[10];
            _11 = p[11];
            _12 = p[12];
            _13 = p[13];
            _14 = p[14];
        }
    }
}

public unsafe struct AVRational_array15
{
    public const int Size = 15;
    public AVRational _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14;
    
    public AVRational this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14 };
    
    public void UpdateFrom(AVRational[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
            _8 = p[8];
            _9 = p[9];
            _10 = p[10];
            _11 = p[11];
            _12 = p[12];
            _13 = p[13];
            _14 = p[14];
        }
    }
}

public unsafe struct byte_array16
{
    public const int Size = 16;
    public fixed byte _[16];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9], _[10], _[11], _[12], _[13], _[14], _[15] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
            _[10] = p[10];
            _[11] = p[11];
            _[12] = p[12];
            _[13] = p[13];
            _[14] = p[14];
            _[15] = p[15];
        }
    }
}

public unsafe struct byte_array17
{
    public const int Size = 17;
    public fixed byte _[17];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9], _[10], _[11], _[12], _[13], _[14], _[15], _[16] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
            _[10] = p[10];
            _[11] = p[11];
            _[12] = p[12];
            _[13] = p[13];
            _[14] = p[14];
            _[15] = p[15];
            _[16] = p[16];
        }
    }
}

public unsafe struct long_array17
{
    public const int Size = 17;
    public fixed long _[17];
    
    public long this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public long[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9], _[10], _[11], _[12], _[13], _[14], _[15], _[16] };
    
    
    public void UpdateFrom(long[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (long* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
            _[10] = p[10];
            _[11] = p[11];
            _[12] = p[12];
            _[13] = p[13];
            _[14] = p[14];
            _[15] = p[15];
            _[16] = p[16];
        }
    }
}

public unsafe struct AVRational_array25
{
    public const int Size = 25;
    public AVRational _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24;
    
    public AVRational this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24 };
    
    public void UpdateFrom(AVRational[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
            _8 = p[8];
            _9 = p[9];
            _10 = p[10];
            _11 = p[11];
            _12 = p[12];
            _13 = p[13];
            _14 = p[14];
            _15 = p[15];
            _16 = p[16];
            _17 = p[17];
            _18 = p[18];
            _19 = p[19];
            _20 = p[20];
            _21 = p[21];
            _22 = p[22];
            _23 = p[23];
            _24 = p[24];
        }
    }
}

public unsafe struct AVRational_array25x25
{
    public const int Size = 25;
    public AVRational_array25 _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24;
    
    public AVRational_array25 this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVRational_array25* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVRational_array25* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVRational_array25[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24 };
    
    public void UpdateFrom(AVRational_array25[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVRational_array25* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
            _8 = p[8];
            _9 = p[9];
            _10 = p[10];
            _11 = p[11];
            _12 = p[12];
            _13 = p[13];
            _14 = p[14];
            _15 = p[15];
            _16 = p[16];
            _17 = p[17];
            _18 = p[18];
            _19 = p[19];
            _20 = p[20];
            _21 = p[21];
            _22 = p[22];
            _23 = p[23];
            _24 = p[24];
        }
    }
}

public unsafe struct byte_array32
{
    public const int Size = 32;
    public fixed byte _[32];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9], _[10], _[11], _[12], _[13], _[14], _[15], _[16], _[17], _[18], _[19], _[20], _[21], _[22], _[23], _[24], _[25], _[26], _[27], _[28], _[29], _[30], _[31] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
            _[10] = p[10];
            _[11] = p[11];
            _[12] = p[12];
            _[13] = p[13];
            _[14] = p[14];
            _[15] = p[15];
            _[16] = p[16];
            _[17] = p[17];
            _[18] = p[18];
            _[19] = p[19];
            _[20] = p[20];
            _[21] = p[21];
            _[22] = p[22];
            _[23] = p[23];
            _[24] = p[24];
            _[25] = p[25];
            _[26] = p[26];
            _[27] = p[27];
            _[28] = p[28];
            _[29] = p[29];
            _[30] = p[30];
            _[31] = p[31];
        }
    }
}

public unsafe struct AVVulkanDeviceQueueFamily_array64
{
    public const int Size = 64;
    public AVVulkanDeviceQueueFamily _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _29, _30, _31, _32, _33, _34, _35, _36, _37, _38, _39, _40, _41, _42, _43, _44, _45, _46, _47, _48, _49, _50, _51, _52, _53, _54, _55, _56, _57, _58, _59, _60, _61, _62, _63;
    
    public AVVulkanDeviceQueueFamily this[int i]
    {
        get
        {
            if (i < 0 || i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size}]");
            fixed (AVVulkanDeviceQueueFamily* p0 = &_0)
            {
                return *(p0 + i);
            }
        }
        set
        {
            if (i >= Size) throw new ArgumentOutOfRangeException($"i({i}) should < {Size}");
            fixed (AVVulkanDeviceQueueFamily* p0 = &_0)
            {
                *(p0 + i) = value;
            }
        }
    }
    
    public AVVulkanDeviceQueueFamily[] ToArray() => new [] { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _29, _30, _31, _32, _33, _34, _35, _36, _37, _38, _39, _40, _41, _42, _43, _44, _45, _46, _47, _48, _49, _50, _51, _52, _53, _54, _55, _56, _57, _58, _59, _60, _61, _62, _63 };
    
    public void UpdateFrom(AVVulkanDeviceQueueFamily[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (AVVulkanDeviceQueueFamily* p = array)
        {
            _0 = p[0];
            _1 = p[1];
            _2 = p[2];
            _3 = p[3];
            _4 = p[4];
            _5 = p[5];
            _6 = p[6];
            _7 = p[7];
            _8 = p[8];
            _9 = p[9];
            _10 = p[10];
            _11 = p[11];
            _12 = p[12];
            _13 = p[13];
            _14 = p[14];
            _15 = p[15];
            _16 = p[16];
            _17 = p[17];
            _18 = p[18];
            _19 = p[19];
            _20 = p[20];
            _21 = p[21];
            _22 = p[22];
            _23 = p[23];
            _24 = p[24];
            _25 = p[25];
            _26 = p[26];
            _27 = p[27];
            _28 = p[28];
            _29 = p[29];
            _30 = p[30];
            _31 = p[31];
            _32 = p[32];
            _33 = p[33];
            _34 = p[34];
            _35 = p[35];
            _36 = p[36];
            _37 = p[37];
            _38 = p[38];
            _39 = p[39];
            _40 = p[40];
            _41 = p[41];
            _42 = p[42];
            _43 = p[43];
            _44 = p[44];
            _45 = p[45];
            _46 = p[46];
            _47 = p[47];
            _48 = p[48];
            _49 = p[49];
            _50 = p[50];
            _51 = p[51];
            _52 = p[52];
            _53 = p[53];
            _54 = p[54];
            _55 = p[55];
            _56 = p[56];
            _57 = p[57];
            _58 = p[58];
            _59 = p[59];
            _60 = p[60];
            _61 = p[61];
            _62 = p[62];
            _63 = p[63];
        }
    }
}

public unsafe struct byte_array64
{
    public const int Size = 64;
    public fixed byte _[64];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray() => new [] { _[0], _[1], _[2], _[3], _[4], _[5], _[6], _[7], _[8], _[9], _[10], _[11], _[12], _[13], _[14], _[15], _[16], _[17], _[18], _[19], _[20], _[21], _[22], _[23], _[24], _[25], _[26], _[27], _[28], _[29], _[30], _[31], _[32], _[33], _[34], _[35], _[36], _[37], _[38], _[39], _[40], _[41], _[42], _[43], _[44], _[45], _[46], _[47], _[48], _[49], _[50], _[51], _[52], _[53], _[54], _[55], _[56], _[57], _[58], _[59], _[60], _[61], _[62], _[63] };
    
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            _[0] = p[0];
            _[1] = p[1];
            _[2] = p[2];
            _[3] = p[3];
            _[4] = p[4];
            _[5] = p[5];
            _[6] = p[6];
            _[7] = p[7];
            _[8] = p[8];
            _[9] = p[9];
            _[10] = p[10];
            _[11] = p[11];
            _[12] = p[12];
            _[13] = p[13];
            _[14] = p[14];
            _[15] = p[15];
            _[16] = p[16];
            _[17] = p[17];
            _[18] = p[18];
            _[19] = p[19];
            _[20] = p[20];
            _[21] = p[21];
            _[22] = p[22];
            _[23] = p[23];
            _[24] = p[24];
            _[25] = p[25];
            _[26] = p[26];
            _[27] = p[27];
            _[28] = p[28];
            _[29] = p[29];
            _[30] = p[30];
            _[31] = p[31];
            _[32] = p[32];
            _[33] = p[33];
            _[34] = p[34];
            _[35] = p[35];
            _[36] = p[36];
            _[37] = p[37];
            _[38] = p[38];
            _[39] = p[39];
            _[40] = p[40];
            _[41] = p[41];
            _[42] = p[42];
            _[43] = p[43];
            _[44] = p[44];
            _[45] = p[45];
            _[46] = p[46];
            _[47] = p[47];
            _[48] = p[48];
            _[49] = p[49];
            _[50] = p[50];
            _[51] = p[51];
            _[52] = p[52];
            _[53] = p[53];
            _[54] = p[54];
            _[55] = p[55];
            _[56] = p[56];
            _[57] = p[57];
            _[58] = p[58];
            _[59] = p[59];
            _[60] = p[60];
            _[61] = p[61];
            _[62] = p[62];
            _[63] = p[63];
        }
    }
}

public unsafe struct byte_array4096
{
    public const int Size = 4096;
    public fixed byte _[4096];
    
    public byte this[int i]
    {
        get => i switch
        {
            >= 0 and < Size => _[i],
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
        set => _[i] = i switch
        {
            >= 0 and < Size => value,
            _ => throw new ArgumentOutOfRangeException($"i({i}) should in [0, {Size})"),
        };
    }
    
    public byte[] ToArray()
    {
        fixed (byte_array4096* p = &this)
        {
            var a = new byte[Size];
            for (uint i = 0; i < Size; i++)
            {
                a[i] = p->_[i];
            }
            return a;
        }
    }
    
    public void UpdateFrom(byte[] array)
    {
        if (array.Length != Size)
        {
            throw new ArgumentOutOfRangeException($"array size({array.Length}) should == {Size}");
        }
        
        fixed (byte* p = array)
        {
            for (int i = 0; i < Size; ++i)
            {
                _[i] = p[i];
            }
        }
    }
}

