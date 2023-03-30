// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: test.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Test.Models.Data {

  /// <summary>Holder for reflection information generated from test.proto</summary>
  public static partial class TestReflection {

    #region Descriptor
    /// <summary>File descriptor for test.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TestReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp0ZXN0LnByb3RvEgR0ZXN0IsUCCghUZXN0RGF0YRIOCgZwYXJhbTEYASAB",
            "KAESDgoGcGFyYW0yGAIgASgCEg4KBnBhcmFtMxgDIAEoAxIOCgZwYXJhbTQY",
            "BCABKAQSDgoGcGFyYW01GAUgASgFEg4KBnBhcmFtNhgGIAEoBhIOCgZwYXJh",
            "bTcYByABKAcSDgoGcGFyYW04GAggASgIEg4KBnBhcmFtORgJIAEoCRIiCgdw",
            "YXJhbTExGAsgASgLMhEudGVzdC5UZXN0U3ViRGF0YRIPCgdwYXJhbTEyGAwg",
            "ASgMEg8KB3BhcmFtMTMYDSABKA0SHwoHcGFyYW0xNBgOIAEoDjIOLnRlc3Qu",
            "VGVzdEVudW0SDwoHcGFyYW0xNRgPIAEoDxIPCgdwYXJhbTE2GBAgASgQEg8K",
            "B3BhcmFtMTcYESABKBESDwoHcGFyYW0xOBgSIAEoEiJdCgtUZXN0U3ViRGF0",
            "YRISCgpzdWJfcGFyYW0xGAEgASgDEhIKCnN1Yl9wYXJhbTIYAiABKAMSEgoK",
            "c3ViX3BhcmFtMxgDIAEoAxISCgpzdWJfcGFyYW00GAQgASgDKocBCghUZXN0",
            "RW51bRISCg5URVNUX0VOVU1fTk9ORRAAEhMKD1RFU1RfRU5VTV9WQUxfQRAB",
            "EhMKD1RFU1RfRU5VTV9WQUxfQhACEhMKD1RFU1RfRU5VTV9WQUxfQxADEhMK",
            "D1RFU1RfRU5VTV9WQUxfRBAEEhMKD1RFU1RfRU5VTV9WQUxfRRAFQh1aCHRl",
            "c3QuY29tqgIQVGVzdC5Nb2RlbHMuRGF0YWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Test.Models.Data.TestEnum), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Test.Models.Data.TestData), global::Test.Models.Data.TestData.Parser, new[]{ "Param1", "Param2", "Param3", "Param4", "Param5", "Param6", "Param7", "Param8", "Param9", "Param11", "Param12", "Param13", "Param14", "Param15", "Param16", "Param17", "Param18" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Test.Models.Data.TestSubData), global::Test.Models.Data.TestSubData.Parser, new[]{ "SubParam1", "SubParam2", "SubParam3", "SubParam4" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum TestEnum {
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_NONE")] None = 0,
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_VAL_A")] ValA = 1,
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_VAL_B")] ValB = 2,
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_VAL_C")] ValC = 3,
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_VAL_D")] ValD = 4,
    /// <summary>
    ///  
    /// </summary>
    [pbr::OriginalName("TEST_ENUM_VAL_E")] ValE = 5,
  }

  #endregion

  #region Messages
  public sealed partial class TestData : pb::IMessage<TestData> {
    private static readonly pb::MessageParser<TestData> _parser = new pb::MessageParser<TestData>(() => new TestData());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TestData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Test.Models.Data.TestReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestData(TestData other) : this() {
      param1_ = other.param1_;
      param2_ = other.param2_;
      param3_ = other.param3_;
      param4_ = other.param4_;
      param5_ = other.param5_;
      param6_ = other.param6_;
      param7_ = other.param7_;
      param8_ = other.param8_;
      param9_ = other.param9_;
      Param11 = other.param11_ != null ? other.Param11.Clone() : null;
      param12_ = other.param12_;
      param13_ = other.param13_;
      param14_ = other.param14_;
      param15_ = other.param15_;
      param16_ = other.param16_;
      param17_ = other.param17_;
      param18_ = other.param18_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestData Clone() {
      return new TestData(this);
    }

    /// <summary>Field number for the "param1" field.</summary>
    public const int Param1FieldNumber = 1;
    private double param1_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Param1 {
      get { return param1_; }
      set {
        param1_ = value;
      }
    }

    /// <summary>Field number for the "param2" field.</summary>
    public const int Param2FieldNumber = 2;
    private float param2_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Param2 {
      get { return param2_; }
      set {
        param2_ = value;
      }
    }

    /// <summary>Field number for the "param3" field.</summary>
    public const int Param3FieldNumber = 3;
    private long param3_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Param3 {
      get { return param3_; }
      set {
        param3_ = value;
      }
    }

    /// <summary>Field number for the "param4" field.</summary>
    public const int Param4FieldNumber = 4;
    private ulong param4_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Param4 {
      get { return param4_; }
      set {
        param4_ = value;
      }
    }

    /// <summary>Field number for the "param5" field.</summary>
    public const int Param5FieldNumber = 5;
    private int param5_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Param5 {
      get { return param5_; }
      set {
        param5_ = value;
      }
    }

    /// <summary>Field number for the "param6" field.</summary>
    public const int Param6FieldNumber = 6;
    private ulong param6_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Param6 {
      get { return param6_; }
      set {
        param6_ = value;
      }
    }

    /// <summary>Field number for the "param7" field.</summary>
    public const int Param7FieldNumber = 7;
    private uint param7_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Param7 {
      get { return param7_; }
      set {
        param7_ = value;
      }
    }

    /// <summary>Field number for the "param8" field.</summary>
    public const int Param8FieldNumber = 8;
    private bool param8_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Param8 {
      get { return param8_; }
      set {
        param8_ = value;
      }
    }

    /// <summary>Field number for the "param9" field.</summary>
    public const int Param9FieldNumber = 9;
    private string param9_ = "";
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Param9 {
      get { return param9_; }
      set {
        param9_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "param11" field.</summary>
    public const int Param11FieldNumber = 11;
    private global::Test.Models.Data.TestSubData param11_;
    /// <summary>
    ///     group param10 = 10; // .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Test.Models.Data.TestSubData Param11 {
      get { return param11_; }
      set {
        param11_ = value;
      }
    }

    /// <summary>Field number for the "param12" field.</summary>
    public const int Param12FieldNumber = 12;
    private pb::ByteString param12_ = pb::ByteString.Empty;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Param12 {
      get { return param12_; }
      set {
        param12_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "param13" field.</summary>
    public const int Param13FieldNumber = 13;
    private uint param13_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Param13 {
      get { return param13_; }
      set {
        param13_ = value;
      }
    }

    /// <summary>Field number for the "param14" field.</summary>
    public const int Param14FieldNumber = 14;
    private global::Test.Models.Data.TestEnum param14_ = 0;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Test.Models.Data.TestEnum Param14 {
      get { return param14_; }
      set {
        param14_ = value;
      }
    }

    /// <summary>Field number for the "param15" field.</summary>
    public const int Param15FieldNumber = 15;
    private int param15_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Param15 {
      get { return param15_; }
      set {
        param15_ = value;
      }
    }

    /// <summary>Field number for the "param16" field.</summary>
    public const int Param16FieldNumber = 16;
    private long param16_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Param16 {
      get { return param16_; }
      set {
        param16_ = value;
      }
    }

    /// <summary>Field number for the "param17" field.</summary>
    public const int Param17FieldNumber = 17;
    private int param17_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Param17 {
      get { return param17_; }
      set {
        param17_ = value;
      }
    }

    /// <summary>Field number for the "param18" field.</summary>
    public const int Param18FieldNumber = 18;
    private long param18_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Param18 {
      get { return param18_; }
      set {
        param18_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TestData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TestData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Param1 != other.Param1) return false;
      if (Param2 != other.Param2) return false;
      if (Param3 != other.Param3) return false;
      if (Param4 != other.Param4) return false;
      if (Param5 != other.Param5) return false;
      if (Param6 != other.Param6) return false;
      if (Param7 != other.Param7) return false;
      if (Param8 != other.Param8) return false;
      if (Param9 != other.Param9) return false;
      if (!object.Equals(Param11, other.Param11)) return false;
      if (Param12 != other.Param12) return false;
      if (Param13 != other.Param13) return false;
      if (Param14 != other.Param14) return false;
      if (Param15 != other.Param15) return false;
      if (Param16 != other.Param16) return false;
      if (Param17 != other.Param17) return false;
      if (Param18 != other.Param18) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Param1 != 0D) hash ^= Param1.GetHashCode();
      if (Param2 != 0F) hash ^= Param2.GetHashCode();
      if (Param3 != 0L) hash ^= Param3.GetHashCode();
      if (Param4 != 0UL) hash ^= Param4.GetHashCode();
      if (Param5 != 0) hash ^= Param5.GetHashCode();
      if (Param6 != 0UL) hash ^= Param6.GetHashCode();
      if (Param7 != 0) hash ^= Param7.GetHashCode();
      if (Param8 != false) hash ^= Param8.GetHashCode();
      if (Param9.Length != 0) hash ^= Param9.GetHashCode();
      if (param11_ != null) hash ^= Param11.GetHashCode();
      if (Param12.Length != 0) hash ^= Param12.GetHashCode();
      if (Param13 != 0) hash ^= Param13.GetHashCode();
      if (Param14 != 0) hash ^= Param14.GetHashCode();
      if (Param15 != 0) hash ^= Param15.GetHashCode();
      if (Param16 != 0L) hash ^= Param16.GetHashCode();
      if (Param17 != 0) hash ^= Param17.GetHashCode();
      if (Param18 != 0L) hash ^= Param18.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Param1 != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Param1);
      }
      if (Param2 != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Param2);
      }
      if (Param3 != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(Param3);
      }
      if (Param4 != 0UL) {
        output.WriteRawTag(32);
        output.WriteUInt64(Param4);
      }
      if (Param5 != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Param5);
      }
      if (Param6 != 0UL) {
        output.WriteRawTag(49);
        output.WriteFixed64(Param6);
      }
      if (Param7 != 0) {
        output.WriteRawTag(61);
        output.WriteFixed32(Param7);
      }
      if (Param8 != false) {
        output.WriteRawTag(64);
        output.WriteBool(Param8);
      }
      if (Param9.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(Param9);
      }
      if (param11_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(Param11);
      }
      if (Param12.Length != 0) {
        output.WriteRawTag(98);
        output.WriteBytes(Param12);
      }
      if (Param13 != 0) {
        output.WriteRawTag(104);
        output.WriteUInt32(Param13);
      }
      if (Param14 != 0) {
        output.WriteRawTag(112);
        output.WriteEnum((int) Param14);
      }
      if (Param15 != 0) {
        output.WriteRawTag(125);
        output.WriteSFixed32(Param15);
      }
      if (Param16 != 0L) {
        output.WriteRawTag(129, 1);
        output.WriteSFixed64(Param16);
      }
      if (Param17 != 0) {
        output.WriteRawTag(136, 1);
        output.WriteSInt32(Param17);
      }
      if (Param18 != 0L) {
        output.WriteRawTag(144, 1);
        output.WriteSInt64(Param18);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Param1 != 0D) {
        size += 1 + 8;
      }
      if (Param2 != 0F) {
        size += 1 + 4;
      }
      if (Param3 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Param3);
      }
      if (Param4 != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Param4);
      }
      if (Param5 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Param5);
      }
      if (Param6 != 0UL) {
        size += 1 + 8;
      }
      if (Param7 != 0) {
        size += 1 + 4;
      }
      if (Param8 != false) {
        size += 1 + 1;
      }
      if (Param9.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Param9);
      }
      if (param11_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Param11);
      }
      if (Param12.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Param12);
      }
      if (Param13 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Param13);
      }
      if (Param14 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Param14);
      }
      if (Param15 != 0) {
        size += 1 + 4;
      }
      if (Param16 != 0L) {
        size += 2 + 8;
      }
      if (Param17 != 0) {
        size += 2 + pb::CodedOutputStream.ComputeSInt32Size(Param17);
      }
      if (Param18 != 0L) {
        size += 2 + pb::CodedOutputStream.ComputeSInt64Size(Param18);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TestData other) {
      if (other == null) {
        return;
      }
      if (other.Param1 != 0D) {
        Param1 = other.Param1;
      }
      if (other.Param2 != 0F) {
        Param2 = other.Param2;
      }
      if (other.Param3 != 0L) {
        Param3 = other.Param3;
      }
      if (other.Param4 != 0UL) {
        Param4 = other.Param4;
      }
      if (other.Param5 != 0) {
        Param5 = other.Param5;
      }
      if (other.Param6 != 0UL) {
        Param6 = other.Param6;
      }
      if (other.Param7 != 0) {
        Param7 = other.Param7;
      }
      if (other.Param8 != false) {
        Param8 = other.Param8;
      }
      if (other.Param9.Length != 0) {
        Param9 = other.Param9;
      }
      if (other.param11_ != null) {
        if (param11_ == null) {
          param11_ = new global::Test.Models.Data.TestSubData();
        }
        Param11.MergeFrom(other.Param11);
      }
      if (other.Param12.Length != 0) {
        Param12 = other.Param12;
      }
      if (other.Param13 != 0) {
        Param13 = other.Param13;
      }
      if (other.Param14 != 0) {
        Param14 = other.Param14;
      }
      if (other.Param15 != 0) {
        Param15 = other.Param15;
      }
      if (other.Param16 != 0L) {
        Param16 = other.Param16;
      }
      if (other.Param17 != 0) {
        Param17 = other.Param17;
      }
      if (other.Param18 != 0L) {
        Param18 = other.Param18;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 9: {
            Param1 = input.ReadDouble();
            break;
          }
          case 21: {
            Param2 = input.ReadFloat();
            break;
          }
          case 24: {
            Param3 = input.ReadInt64();
            break;
          }
          case 32: {
            Param4 = input.ReadUInt64();
            break;
          }
          case 40: {
            Param5 = input.ReadInt32();
            break;
          }
          case 49: {
            Param6 = input.ReadFixed64();
            break;
          }
          case 61: {
            Param7 = input.ReadFixed32();
            break;
          }
          case 64: {
            Param8 = input.ReadBool();
            break;
          }
          case 74: {
            Param9 = input.ReadString();
            break;
          }
          case 90: {
            if (param11_ == null) {
              param11_ = new global::Test.Models.Data.TestSubData();
            }
            input.ReadMessage(param11_);
            break;
          }
          case 98: {
            Param12 = input.ReadBytes();
            break;
          }
          case 104: {
            Param13 = input.ReadUInt32();
            break;
          }
          case 112: {
            param14_ = (global::Test.Models.Data.TestEnum) input.ReadEnum();
            break;
          }
          case 125: {
            Param15 = input.ReadSFixed32();
            break;
          }
          case 129: {
            Param16 = input.ReadSFixed64();
            break;
          }
          case 136: {
            Param17 = input.ReadSInt32();
            break;
          }
          case 144: {
            Param18 = input.ReadSInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class TestSubData : pb::IMessage<TestSubData> {
    private static readonly pb::MessageParser<TestSubData> _parser = new pb::MessageParser<TestSubData>(() => new TestSubData());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TestSubData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Test.Models.Data.TestReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestSubData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestSubData(TestSubData other) : this() {
      subParam1_ = other.subParam1_;
      subParam2_ = other.subParam2_;
      subParam3_ = other.subParam3_;
      subParam4_ = other.subParam4_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestSubData Clone() {
      return new TestSubData(this);
    }

    /// <summary>Field number for the "sub_param1" field.</summary>
    public const int SubParam1FieldNumber = 1;
    private long subParam1_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long SubParam1 {
      get { return subParam1_; }
      set {
        subParam1_ = value;
      }
    }

    /// <summary>Field number for the "sub_param2" field.</summary>
    public const int SubParam2FieldNumber = 2;
    private long subParam2_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long SubParam2 {
      get { return subParam2_; }
      set {
        subParam2_ = value;
      }
    }

    /// <summary>Field number for the "sub_param3" field.</summary>
    public const int SubParam3FieldNumber = 3;
    private long subParam3_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long SubParam3 {
      get { return subParam3_; }
      set {
        subParam3_ = value;
      }
    }

    /// <summary>Field number for the "sub_param4" field.</summary>
    public const int SubParam4FieldNumber = 4;
    private long subParam4_;
    /// <summary>
    ///  .
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long SubParam4 {
      get { return subParam4_; }
      set {
        subParam4_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TestSubData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TestSubData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SubParam1 != other.SubParam1) return false;
      if (SubParam2 != other.SubParam2) return false;
      if (SubParam3 != other.SubParam3) return false;
      if (SubParam4 != other.SubParam4) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SubParam1 != 0L) hash ^= SubParam1.GetHashCode();
      if (SubParam2 != 0L) hash ^= SubParam2.GetHashCode();
      if (SubParam3 != 0L) hash ^= SubParam3.GetHashCode();
      if (SubParam4 != 0L) hash ^= SubParam4.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SubParam1 != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(SubParam1);
      }
      if (SubParam2 != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(SubParam2);
      }
      if (SubParam3 != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(SubParam3);
      }
      if (SubParam4 != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(SubParam4);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SubParam1 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(SubParam1);
      }
      if (SubParam2 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(SubParam2);
      }
      if (SubParam3 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(SubParam3);
      }
      if (SubParam4 != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(SubParam4);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TestSubData other) {
      if (other == null) {
        return;
      }
      if (other.SubParam1 != 0L) {
        SubParam1 = other.SubParam1;
      }
      if (other.SubParam2 != 0L) {
        SubParam2 = other.SubParam2;
      }
      if (other.SubParam3 != 0L) {
        SubParam3 = other.SubParam3;
      }
      if (other.SubParam4 != 0L) {
        SubParam4 = other.SubParam4;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            SubParam1 = input.ReadInt64();
            break;
          }
          case 16: {
            SubParam2 = input.ReadInt64();
            break;
          }
          case 24: {
            SubParam3 = input.ReadInt64();
            break;
          }
          case 32: {
            SubParam4 = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code