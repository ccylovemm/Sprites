using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FileReadStream {
	private byte[] _bytes;
	private int _pos = 0;
	
	private static System.Text.UTF8Encoding _conv = new System.Text.UTF8Encoding();
	
	public FileReadStream(byte[] bytes)
	{
		_bytes = bytes;
	}

	public Boolean bytesAvailable
	{
		get
		{
			return _bytes.Length > _pos;
		}
	}

	bool CheckSize(UInt16 size)
	{
		return _bytes.Length >= _pos + size;
	}
	
	public UInt16 ReadArrayLength()
	{
		return ReadUInt16();
	}
	
	public Byte ReadUInt8()
	{
		return _bytes[_pos++];
	}
	
	public UInt16 ReadUInt16()
	{
		_pos += sizeof(UInt16);
		return BitConverter.ToUInt16(_bytes, _pos - sizeof(UInt16));
	}
	
	public UInt32 ReadUInt32()
	{
		_pos += sizeof(UInt32);
		return BitConverter.ToUInt32(_bytes, _pos - sizeof(UInt32));
	}
	
	public UInt64 ReadUInt64()
	{
		_pos += sizeof(UInt64);
		return BitConverter.ToUInt64(_bytes, _pos - sizeof(UInt64));
	}
	
	public SByte ReadInt8()
	{
		return (SByte)_bytes[_pos++];
	}
	
	public Int16 ReadInt16()
	{
		_pos += sizeof(Int16);
		return BitConverter.ToInt16(_bytes, _pos - sizeof(Int16));
	}
	
	public Int32 ReadInt32()
	{
		_pos += sizeof(Int32);
		return BitConverter.ToInt32(_bytes, _pos - sizeof(Int32));
	}
	
	public Int64 ReadInt64()
	{
		_pos += sizeof(Int64);
		return BitConverter.ToInt64(_bytes, _pos - sizeof(Int64));
	}
	
	public bool ReadBool()
	{
		_pos += sizeof(bool);
		return BitConverter.ToBoolean(_bytes, _pos - sizeof(bool));
	}
	
	public float ReadFloat()
	{
		_pos += sizeof(float);
		return (float)BitConverter.ToSingle(_bytes, _pos - sizeof(float));
	}
	
	public double ReadDouble()
	{
		_pos += sizeof(double);
		return BitConverter.ToDouble(_bytes, _pos - sizeof(double));
	}
	
	public string ReadString()
	{
		if (!CheckSize((UInt16)2))
			return null;
		UInt16 len = ReadUInt16();
		if (!CheckSize(len))
			return null;
		string str = _conv.GetString(_bytes, _pos, len);
		_pos += len;
		return str;
	}
	
	public List<Byte> ReadVecUInt8()
	{
		UInt16 len = ReadArrayLength();
		List<Byte> val = new List<Byte>(len);
		for (int i = 0; i < len; ++i)
			val.Add(ReadUInt8());
		return val;
	}
	
	public List<Byte> ReadVec2UInt8()
	{
		List<Byte> vec = new List<Byte>();
		while (true)
		{
			Byte v = ReadUInt8();
			if (v == 0)
				break;
			vec.Add(v);
		}
		
		return vec;
	}
	
	public List<SByte> ReadVecInt8()
	{
		UInt16 len = ReadArrayLength();
		List<SByte> vec = new List<SByte>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadInt8());
		return vec;
	}
	
	public List<SByte> ReadVec2Int8()
	{
		List<SByte> vec = new List<SByte>();
		while (true)
		{
			SByte v = ReadInt8();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<UInt16> ReadVecUInt16()
	{
		UInt16 len = ReadArrayLength();
		List<UInt16> vec = new List<UInt16>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadUInt16());
		return vec;
	}
	
	public List<UInt16> ReadVec2UInt16()
	{
		List<UInt16> vec = new List<UInt16>();
		while (true)
		{
			UInt16 v = ReadUInt16();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<Int16> ReadVecInt16()
	{
		UInt16 len = ReadArrayLength();
		List<Int16> vec = new List<Int16>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadInt16());
		return vec;
	}
	
	public List<Int16> ReadVec2Int16()
	{
		List<Int16> vec = new List<Int16>();
		while (true)
		{
			Int16 v = ReadInt16();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<UInt32> ReadVecUInt32()
	{
		UInt16 len = ReadArrayLength();
		List<UInt32> vec = new List<UInt32>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadUInt32());
		return vec;
	}
	
	public List<UInt32> ReadVec2UInt32()
	{
		List<UInt32> vec = new List<UInt32>();
		while (true)
		{
			UInt32 v = ReadUInt32();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<Int32> ReadVecInt32()
	{
		UInt16 len = ReadArrayLength();
		List<Int32> vec = new List<Int32>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadInt32());
		return vec;
	}
	
	public List<Int32> ReadVec2Int32()
	{
		List<Int32> vec = new List<Int32>();
		while (true)
		{
			Int32 v = ReadInt32();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<UInt64> ReadVecUInt64()
	{
		UInt16 len = ReadArrayLength();
		List<UInt64> vec = new List<UInt64>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadUInt64());
		return vec;
	}
	
	public List<UInt64> ReadVec2UInt64()
	{
		List<UInt64> vec = new List<UInt64>();
		while (true)
		{
			UInt64 v = ReadUInt64();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<bool> ReadVecBool()
	{
		UInt16 len = ReadArrayLength();
		List<bool> vec = new List<bool>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadBool());
		return vec;
	}
	
	public List<float> ReadVecFloat()
	{
		UInt16 len = ReadArrayLength();
		List<float> vec = new List<float>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadFloat());
		return vec;
	}
	
	public List<float> ReadVec2Float()
	{
		List<float> vec = new List<float>();
		while (true)
		{
			float v = ReadFloat();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<double> ReadVecDouble()
	{
		UInt16 len = ReadArrayLength();
		List<double> vec = new List<double>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadDouble());
		return vec;
	}
	
	public List<double> ReadVec2Double()
	{
		List<double> vec = new List<double>();
		while (true)
		{
			double v = ReadDouble();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<string> ReadVecString()
	{
		UInt16 len = ReadArrayLength();
		List<string> vec = new List<string>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadString());
		return vec;
	}
	
	public List<string> ReadVec2String()
	{
		List<string> vec = new List<string>();
		while (true)
		{
			string v = ReadString();
			if (v.Length == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
	
	public List<Int64> ReadVecInt64()
	{
		UInt16 len = ReadUInt16();
		List<Int64> vec = new List<Int64>(len);
		for (int i = 0; i < len; ++i)
			vec.Add(ReadInt64());
		return vec;
	}
	
	public List<Int64> ReadVec2Int64()
	{
		List<Int64> vec = new List<Int64>();
		while (true)
		{
			Int64 v = ReadInt64();
			if (v == 0)
				break;
			vec.Add(v);
		}
		return vec;
	}
}

