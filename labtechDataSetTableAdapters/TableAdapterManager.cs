using LTQATools;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace LTQATools.labtechDataSetTableAdapters
{
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapterManager")]
	[ToolboxItem(true)]
	public class TableAdapterManager : Component
	{
		private TableAdapterManager.UpdateOrderOption _updateOrder;

		private bool _backupDataSetBeforeUpdate;

		private IDbConnection _connection;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool BackupDataSetBeforeUpdate
		{
			get
			{
				return this._backupDataSetBeforeUpdate;
			}
			set
			{
				this._backupDataSetBeforeUpdate = value;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public IDbConnection Connection
		{
			get
			{
				IDbConnection dbConnection;
				if (this._connection == null)
				{
					dbConnection = null;
				}
				else
				{
					dbConnection = this._connection;
				}
				return dbConnection;
			}
			set
			{
				this._connection = value;
			}
		}

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int TableAdapterInstanceCount
		{
			get
			{
				return 0;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public TableAdapterManager.UpdateOrderOption UpdateOrder
		{
			get
			{
				return this._updateOrder;
			}
			set
			{
				this._updateOrder = value;
			}
		}

		public TableAdapterManager()
		{
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
		{
			DataRow[] array;
			if (!(updatedRows == null ? false : (int)updatedRows.Length >= 1))
			{
				array = updatedRows;
			}
			else if ((allAddedRows == null ? false : allAddedRows.Count >= 1))
			{
				List<DataRow> dataRows = new List<DataRow>();
				for (int i = 0; i < (int)updatedRows.Length; i++)
				{
					DataRow dataRow = updatedRows[i];
					if (!allAddedRows.Contains(dataRow))
					{
						dataRows.Add(dataRow);
					}
				}
				array = dataRows.ToArray();
			}
			else
			{
				array = updatedRows;
			}
			return array;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection)
		{
			bool flag;
			if (this._connection != null)
			{
				flag = true;
			}
			else if ((this.Connection == null ? false : inputConnection != null))
			{
				flag = (!string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal) ? false : true);
			}
			else
			{
				flag = true;
			}
			return flag;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected virtual void SortSelfReferenceRows(DataRow[] rows, DataRelation relation, bool childFirst)
		{
			Array.Sort<DataRow>(rows, new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public virtual int UpdateAll(labtechDataSet dataSet)
		{
			DataRow[] dataRowArray;
			int i;
			DataRow dataRow;
			int num;
			if (dataSet == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			if (dataSet.HasChanges())
			{
				IDbConnection connection = this.Connection;
				if (connection == null)
				{
					throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
				}
				bool flag = false;
				if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
				{
					connection.Close();
				}
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
					flag = true;
				}
				IDbTransaction dbTransaction = connection.BeginTransaction();
				if (dbTransaction == null)
				{
					throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
				}
				List<DataRow> dataRows = new List<DataRow>();
				List<DataRow> dataRows1 = new List<DataRow>();
				List<DataAdapter> dataAdapters = new List<DataAdapter>();
				Dictionary<object, IDbConnection> objs = new Dictionary<object, IDbConnection>();
				int num1 = 0;
				DataSet dataSet1 = null;
				if (this.BackupDataSetBeforeUpdate)
				{
					dataSet1 = new DataSet();
					dataSet1.Merge(dataSet);
				}
				try
				{
					try
					{
						if (this.UpdateOrder != TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
						{
							num1 += this.UpdateInsertedRows(dataSet, dataRows1);
							num1 += this.UpdateUpdatedRows(dataSet, dataRows, dataRows1);
						}
						else
						{
							num1 += this.UpdateUpdatedRows(dataSet, dataRows, dataRows1);
							num1 += this.UpdateInsertedRows(dataSet, dataRows1);
						}
						num1 += this.UpdateDeletedRows(dataSet, dataRows);
						dbTransaction.Commit();
						if (0 < dataRows1.Count)
						{
							dataRowArray = new DataRow[dataRows1.Count];
							dataRows1.CopyTo(dataRowArray);
							for (i = 0; i < (int)dataRowArray.Length; i++)
							{
								dataRow = dataRowArray[i];
								dataRow.AcceptChanges();
							}
						}
						if (0 < dataRows.Count)
						{
							dataRowArray = new DataRow[dataRows.Count];
							dataRows.CopyTo(dataRowArray);
							for (i = 0; i < (int)dataRowArray.Length; i++)
							{
								dataRow = dataRowArray[i];
								dataRow.AcceptChanges();
							}
						}
					}
					catch (Exception exception1)
					{
						Exception exception = exception1;
						dbTransaction.Rollback();
						if (this.BackupDataSetBeforeUpdate)
						{
							Debug.Assert(dataSet1 != null);
							dataSet.Clear();
							dataSet.Merge(dataSet1);
						}
						else if (0 < dataRows1.Count)
						{
							dataRowArray = new DataRow[dataRows1.Count];
							dataRows1.CopyTo(dataRowArray);
							for (i = 0; i < (int)dataRowArray.Length; i++)
							{
								dataRow = dataRowArray[i];
								dataRow.AcceptChanges();
								dataRow.SetAdded();
							}
						}
						throw exception;
					}
				}
				finally
				{
					if (flag)
					{
						connection.Close();
					}
					if (0 < dataAdapters.Count)
					{
						DataAdapter[] dataAdapterArray = new DataAdapter[dataAdapters.Count];
						dataAdapters.CopyTo(dataAdapterArray);
						for (i = 0; i < (int)dataAdapterArray.Length; i++)
						{
							dataAdapterArray[i].AcceptChangesDuringUpdate = true;
						}
					}
				}
				num = num1;
			}
			else
			{
				num = 0;
			}
			return num;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateDeletedRows(labtechDataSet dataSet, List<DataRow> allChangedRows)
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateInsertedRows(labtechDataSet dataSet, List<DataRow> allAddedRows)
		{
			return 0;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private int UpdateUpdatedRows(labtechDataSet dataSet, List<DataRow> allChangedRows, List<DataRow> allAddedRows)
		{
			return 0;
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private class SelfReferenceComparer : IComparer<DataRow>
		{
			private DataRelation _relation;

			private int _childFirst;

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			internal SelfReferenceComparer(DataRelation relation, bool childFirst)
			{
				this._relation = relation;
				if (!childFirst)
				{
					this._childFirst = 1;
				}
				else
				{
					this._childFirst = -1;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			public int Compare(DataRow row1, DataRow row2)
			{
				int num;
				if (object.ReferenceEquals(row1, row2))
				{
					num = 0;
				}
				else if (row1 == null)
				{
					num = -1;
				}
				else if (row2 != null)
				{
					int num1 = 0;
					DataRow root = this.GetRoot(row1, out num1);
					int num2 = 0;
					DataRow dataRow = this.GetRoot(row2, out num2);
					if (!object.ReferenceEquals(root, dataRow))
					{
						Debug.Assert((root.Table == null ? false : dataRow.Table != null));
						num = (root.Table.Rows.IndexOf(root) >= dataRow.Table.Rows.IndexOf(dataRow) ? 1 : -1);
					}
					else
					{
						num = this._childFirst * num1.CompareTo(num2);
					}
				}
				else
				{
					num = 1;
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
			private DataRow GetRoot(DataRow row, out int distance)
			{
				Debug.Assert(row != null);
				DataRow dataRow = row;
				distance = 0;
				IDictionary<DataRow, DataRow> dataRows = new Dictionary<DataRow, DataRow>();
				dataRows[row] = row;
				DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Default);
				while (true)
				{
					if ((parentRow == null ? true : dataRows.ContainsKey(parentRow)))
					{
						break;
					}
					distance++;
					dataRow = parentRow;
					dataRows[parentRow] = parentRow;
					parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default);
				}
				if (distance == 0)
				{
					dataRows.Clear();
					dataRows[row] = row;
					parentRow = row.GetParentRow(this._relation, DataRowVersion.Original);
					while (true)
					{
						if ((parentRow == null ? true : dataRows.ContainsKey(parentRow)))
						{
							break;
						}
						distance++;
						dataRow = parentRow;
						dataRows[parentRow] = parentRow;
						parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original);
					}
				}
				return dataRow;
			}
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public enum UpdateOrderOption
		{
			InsertUpdateDelete,
			UpdateInsertDelete
		}
	}
}