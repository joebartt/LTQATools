using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace LTQATools
{
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.DataSet")]
	[Serializable]
	[ToolboxItem(true)]
	[XmlRoot("labtechDataSet")]
	[XmlSchemaProvider("GetTypedDataSetSchema")]
	public class labtechDataSet : DataSet
	{
		private labtechDataSet.computersDataTable tablecomputers;

		private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

		[Browsable(false)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public labtechDataSet.computersDataTable computers
		{
			get
			{
				return this.tablecomputers;
			}
		}

		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public new DataRelationCollection Relations
		{
			get
			{
				return base.Relations;
			}
		}

		[Browsable(true)]
		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override System.Data.SchemaSerializationMode SchemaSerializationMode
		{
			get
			{
				return this._schemaSerializationMode;
			}
			set
			{
				this._schemaSerializationMode = value;
			}
		}

		[DebuggerNonUserCode]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public new DataTableCollection Tables
		{
			get
			{
				return base.Tables;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public labtechDataSet()
		{
			base.BeginInit();
			this.InitClass();
			CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
			base.Tables.CollectionChanged += collectionChangeEventHandler;
			base.Relations.CollectionChanged += collectionChangeEventHandler;
			base.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected labtechDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
		{
			if (!base.IsBinarySerialized(info, context))
			{
				string value = (string)info.GetValue("XmlSchema", typeof(string));
				if (base.DetermineSchemaSerializationMode(info, context) != System.Data.SchemaSerializationMode.IncludeSchema)
				{
					base.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
				}
				else
				{
					DataSet dataSet = new DataSet();
					dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
					if (dataSet.Tables["computers"] != null)
					{
						base.Tables.Add(new labtechDataSet.computersDataTable(dataSet.Tables["computers"]));
					}
					base.DataSetName = dataSet.DataSetName;
					base.Prefix = dataSet.Prefix;
					base.Namespace = dataSet.Namespace;
					base.Locale = dataSet.Locale;
					base.CaseSensitive = dataSet.CaseSensitive;
					base.EnforceConstraints = dataSet.EnforceConstraints;
					base.Merge(dataSet, false, MissingSchemaAction.Add);
					this.InitVars();
				}
				base.GetSerializationData(info, context);
				CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
				base.Tables.CollectionChanged += collectionChangeEventHandler;
				this.Relations.CollectionChanged += collectionChangeEventHandler;
			}
			else
			{
				this.InitVars(false);
				CollectionChangeEventHandler collectionChangeEventHandler1 = new CollectionChangeEventHandler(this.SchemaChanged);
				this.Tables.CollectionChanged += collectionChangeEventHandler1;
				this.Relations.CollectionChanged += collectionChangeEventHandler1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataSet Clone()
		{
			labtechDataSet schemaSerializationMode = (labtechDataSet)base.Clone();
			schemaSerializationMode.InitVars();
			schemaSerializationMode.SchemaSerializationMode = this.SchemaSerializationMode;
			return schemaSerializationMode;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override XmlSchema GetSchemaSerializable()
		{
			MemoryStream memoryStream = new MemoryStream();
			base.WriteXmlSchema(new XmlTextWriter(memoryStream, null));
			memoryStream.Position = (long)0;
			return XmlSchema.Read(new XmlTextReader(memoryStream), null);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			labtechDataSet _labtechDataSet = new labtechDataSet();
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
			{
				Namespace = _labtechDataSet.Namespace
			};
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = _labtechDataSet.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream1 = new MemoryStream();
				try
				{
					XmlSchema current = null;
					schemaSerializable.Write(memoryStream);
					IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
					while (enumerator.MoveNext())
					{
						current = (XmlSchema)enumerator.Current;
						memoryStream1.SetLength((long)0);
						current.Write(memoryStream1);
						if (memoryStream.Length == memoryStream1.Length)
						{
							memoryStream.Position = (long)0;
							memoryStream1.Position = (long)0;
							while (true)
							{
								if ((memoryStream.Position == memoryStream.Length ? true : memoryStream.ReadByte() != memoryStream1.ReadByte()))
								{
									break;
								}
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								xmlSchemaComplexType = xmlSchemaComplexType1;
								return xmlSchemaComplexType;
							}
						}
					}
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream1 != null)
					{
						memoryStream1.Close();
					}
				}
			}
			xs.Add(schemaSerializable);
			xmlSchemaComplexType = xmlSchemaComplexType1;
			return xmlSchemaComplexType;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitClass()
		{
			base.DataSetName = "labtechDataSet";
			base.Prefix = "";
			base.Namespace = "http://tempuri.org/labtechDataSet.xsd";
			base.EnforceConstraints = true;
			this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			this.tablecomputers = new labtechDataSet.computersDataTable();
			base.Tables.Add(this.tablecomputers);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void InitializeDerivedDataSet()
		{
			base.BeginInit();
			this.InitClass();
			base.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.InitVars(true);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars(bool initTable)
		{
			this.tablecomputers = (labtechDataSet.computersDataTable)base.Tables["computers"];
			if (initTable)
			{
				if (this.tablecomputers != null)
				{
					this.tablecomputers.InitVars();
				}
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void ReadXmlSerializable(XmlReader reader)
		{
			if (base.DetermineSchemaSerializationMode(reader) != System.Data.SchemaSerializationMode.IncludeSchema)
			{
				base.ReadXml(reader);
				this.InitVars();
			}
			else
			{
				this.Reset();
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(reader);
				if (dataSet.Tables["computers"] != null)
				{
					base.Tables.Add(new labtechDataSet.computersDataTable(dataSet.Tables["computers"]));
				}
				base.DataSetName = dataSet.DataSetName;
				base.Prefix = dataSet.Prefix;
				base.Namespace = dataSet.Namespace;
				base.Locale = dataSet.Locale;
				base.CaseSensitive = dataSet.CaseSensitive;
				base.EnforceConstraints = dataSet.EnforceConstraints;
				base.Merge(dataSet, false, MissingSchemaAction.Add);
				this.InitVars();
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void SchemaChanged(object sender, CollectionChangeEventArgs e)
		{
			if (e.Action == CollectionChangeAction.Remove)
			{
				this.InitVars();
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private bool ShouldSerializecomputers()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override bool ShouldSerializeRelations()
		{
			return false;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override bool ShouldSerializeTables()
		{
			return false;
		}

		[Serializable]
		[XmlSchemaProvider("GetTypedTableSchema")]
		public class computersDataTable : TypedTableBase<labtechDataSet.computersRow>
		{
			private DataColumn columnComputerID;

			private DataColumn columnName;

			private DataColumn columnflags;

			private DataColumn columnFeatureFlags;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn ComputerIDColumn
			{
				get
				{
					return this.columnComputerID;
				}
			}

			[Browsable(false)]
			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Count
			{
				get
				{
					return base.Rows.Count;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn FeatureFlagsColumn
			{
				get
				{
					return this.columnFeatureFlags;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn flagsColumn
			{
				get
				{
					return this.columnflags;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public labtechDataSet.computersRow this[int index]
			{
				get
				{
					return (labtechDataSet.computersRow)base.Rows[index];
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataColumn NameColumn
			{
				get
				{
					return this.columnName;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public computersDataTable()
			{
				base.TableName = "computers";
				this.BeginInit();
				this.InitClass();
				this.EndInit();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal computersDataTable(DataTable table)
			{
				base.TableName = table.TableName;
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					base.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					base.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					base.Namespace = table.Namespace;
				}
				base.Prefix = table.Prefix;
				base.MinimumCapacity = table.MinimumCapacity;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected computersDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				this.InitVars();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void AddcomputersRow(labtechDataSet.computersRow row)
			{
				base.Rows.Add(row);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public labtechDataSet.computersRow AddcomputersRow(string Name, int flags, int FeatureFlags)
			{
				labtechDataSet.computersRow _computersRow = (labtechDataSet.computersRow)base.NewRow();
				object[] name = new object[] { null, Name, flags, FeatureFlags };
				_computersRow.ItemArray = name;
				base.Rows.Add(_computersRow);
				return _computersRow;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public override DataTable Clone()
			{
				labtechDataSet.computersDataTable _computersDataTable = (labtechDataSet.computersDataTable)base.Clone();
				_computersDataTable.InitVars();
				return _computersDataTable;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataTable CreateInstance()
			{
				return new labtechDataSet.computersDataTable();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public labtechDataSet.computersRow FindByComputerID(int ComputerID)
			{
				DataRowCollection rows = base.Rows;
				object[] computerID = new object[] { ComputerID };
				return (labtechDataSet.computersRow)rows.Find(computerID);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override Type GetRowType()
			{
				return typeof(labtechDataSet.computersRow);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
			{
				XmlSchemaComplexType xmlSchemaComplexType;
				XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
				XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
				labtechDataSet _labtechDataSet = new labtechDataSet();
				XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
				{
					Namespace = "http://www.w3.org/2001/XMLSchema",
					MinOccurs = new decimal(0),
					MaxOccurs = new decimal(-1, -1, -1, false, 0),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny);
				XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
				{
					Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
					MinOccurs = new decimal(1),
					ProcessContents = XmlSchemaContentProcessing.Lax
				};
				xmlSchemaSequence.Items.Add(xmlSchemaAny1);
				XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
				{
					Name = "namespace",
					FixedValue = _labtechDataSet.Namespace
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
				XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
				{
					Name = "tableTypeName",
					FixedValue = "computersDataTable"
				};
				xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
				xmlSchemaComplexType1.Particle = xmlSchemaSequence;
				XmlSchema schemaSerializable = _labtechDataSet.GetSchemaSerializable();
				if (xs.Contains(schemaSerializable.TargetNamespace))
				{
					MemoryStream memoryStream = new MemoryStream();
					MemoryStream memoryStream1 = new MemoryStream();
					try
					{
						XmlSchema current = null;
						schemaSerializable.Write(memoryStream);
						IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
						while (enumerator.MoveNext())
						{
							current = (XmlSchema)enumerator.Current;
							memoryStream1.SetLength((long)0);
							current.Write(memoryStream1);
							if (memoryStream.Length == memoryStream1.Length)
							{
								memoryStream.Position = (long)0;
								memoryStream1.Position = (long)0;
								while (true)
								{
									if ((memoryStream.Position == memoryStream.Length ? true : memoryStream.ReadByte() != memoryStream1.ReadByte()))
									{
										break;
									}
								}
								if (memoryStream.Position == memoryStream.Length)
								{
									xmlSchemaComplexType = xmlSchemaComplexType1;
									return xmlSchemaComplexType;
								}
							}
						}
					}
					finally
					{
						if (memoryStream != null)
						{
							memoryStream.Close();
						}
						if (memoryStream1 != null)
						{
							memoryStream1.Close();
						}
					}
				}
				xs.Add(schemaSerializable);
				xmlSchemaComplexType = xmlSchemaComplexType1;
				return xmlSchemaComplexType;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private void InitClass()
			{
				this.columnComputerID = new DataColumn("ComputerID", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnComputerID);
				this.columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
				base.Columns.Add(this.columnName);
				this.columnflags = new DataColumn("flags", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnflags);
				this.columnFeatureFlags = new DataColumn("FeatureFlags", typeof(int), null, MappingType.Element);
				base.Columns.Add(this.columnFeatureFlags);
				ConstraintCollection constraints = base.Constraints;
				DataColumn[] dataColumnArray = new DataColumn[] { this.columnComputerID };
				constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
				this.columnComputerID.AutoIncrement = true;
				this.columnComputerID.AutoIncrementSeed = (long)-1;
				this.columnComputerID.AutoIncrementStep = (long)-1;
				this.columnComputerID.AllowDBNull = false;
				this.columnComputerID.Unique = true;
				this.columnName.AllowDBNull = false;
				this.columnName.MaxLength = 50;
				this.columnflags.AllowDBNull = false;
				this.columnFeatureFlags.AllowDBNull = false;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal void InitVars()
			{
				this.columnComputerID = base.Columns["ComputerID"];
				this.columnName = base.Columns["Name"];
				this.columnflags = base.Columns["flags"];
				this.columnFeatureFlags = base.Columns["FeatureFlags"];
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public labtechDataSet.computersRow NewcomputersRow()
			{
				return (labtechDataSet.computersRow)base.NewRow();
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new labtechDataSet.computersRow(builder);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (this.computersRowChanged != null)
				{
					this.computersRowChanged(this, new labtechDataSet.computersRowChangeEvent((labtechDataSet.computersRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (this.computersRowChanging != null)
				{
					this.computersRowChanging(this, new labtechDataSet.computersRowChangeEvent((labtechDataSet.computersRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (this.computersRowDeleted != null)
				{
					this.computersRowDeleted(this, new labtechDataSet.computersRowChangeEvent((labtechDataSet.computersRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (this.computersRowDeleting != null)
				{
					this.computersRowDeleting(this, new labtechDataSet.computersRowChangeEvent((labtechDataSet.computersRow)e.Row, e.Action));
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public void RemovecomputersRow(labtechDataSet.computersRow row)
			{
				base.Rows.Remove(row);
			}

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event labtechDataSet.computersRowChangeEventHandler computersRowChanged;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event labtechDataSet.computersRowChangeEventHandler computersRowChanging;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event labtechDataSet.computersRowChangeEventHandler computersRowDeleted;

			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public event labtechDataSet.computersRowChangeEventHandler computersRowDeleting;
		}

		public class computersRow : DataRow
		{
			private labtechDataSet.computersDataTable tablecomputers;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int ComputerID
			{
				get
				{
					return (int)base[this.tablecomputers.ComputerIDColumn];
				}
				set
				{
					base[this.tablecomputers.ComputerIDColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int FeatureFlags
			{
				get
				{
					return (int)base[this.tablecomputers.FeatureFlagsColumn];
				}
				set
				{
					base[this.tablecomputers.FeatureFlagsColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int flags
			{
				get
				{
					return (int)base[this.tablecomputers.flagsColumn];
				}
				set
				{
					base[this.tablecomputers.flagsColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public string Name
			{
				get
				{
					return (string)base[this.tablecomputers.NameColumn];
				}
				set
				{
					base[this.tablecomputers.NameColumn] = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal computersRow(DataRowBuilder rb) : base(rb)
			{
				this.tablecomputers = (labtechDataSet.computersDataTable)base.Table;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public class computersRowChangeEvent : EventArgs
		{
			private labtechDataSet.computersRow eventRow;

			private DataRowAction eventAction;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public labtechDataSet.computersRow Row
			{
				get
				{
					return this.eventRow;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public computersRowChangeEvent(labtechDataSet.computersRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public delegate void computersRowChangeEventHandler(object sender, labtechDataSet.computersRowChangeEvent e);
	}
}