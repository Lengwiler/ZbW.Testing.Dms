﻿using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.Services.Impl;

namespace ZbW.Testing.Dms.Client.ViewModels
{
  public class DocumentDetailViewModel : BindableBase
  {
    private readonly Action _navigateBack;

    private string _benutzer;

    private string _bezeichnung;

    private DateTime _erfassungsdatum;

    private string _filePath;
    private readonly FileSystemService _fileSystemService;

    private bool _isRemoveFileEnabled;
    private IMetadataItem _metadataItem;

    private string _selectedTypItem;

    private string _stichwoerter;

    private List<string> _typItems;

    private DateTime? _valutaDatum;

    public DocumentDetailViewModel(string benutzer, Action navigateBack)
    {
      _navigateBack = navigateBack;
      Benutzer = benutzer;
      Erfassungsdatum = DateTime.Now;
      TypItems = ComboBoxItems.Typ;

      CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
      CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
      _fileSystemService = new FileSystemService();
    }

    public string Stichwoerter
    {
      get { return _stichwoerter; }

      set { SetProperty(ref _stichwoerter, value); }
    }

    public string Bezeichnung
    {
      get { return _bezeichnung; }

      set { SetProperty(ref _bezeichnung, value); }
    }

    public List<string> TypItems
    {
      get { return _typItems; }

      set { SetProperty(ref _typItems, value); }
    }

    public string SelectedTypItem
    {
      get { return _selectedTypItem; }

      set { SetProperty(ref _selectedTypItem, value); }
    }

    public DateTime Erfassungsdatum
    {
      get { return _erfassungsdatum; }

      set { SetProperty(ref _erfassungsdatum, value); }
    }

    public string Benutzer
    {
      get { return _benutzer; }

      set { SetProperty(ref _benutzer, value); }
    }

    public DelegateCommand CmdDurchsuchen { get; }

    public DelegateCommand CmdSpeichern { get; }

    public DateTime? ValutaDatum
    {
      get { return _valutaDatum; }

      set { SetProperty(ref _valutaDatum, value); }
    }

    public bool IsRemoveFileEnabled
    {
      get { return _isRemoveFileEnabled; }

      set { SetProperty(ref _isRemoveFileEnabled, value); }
    }

    private void OnCmdDurchsuchen()
    {
      var openFileDialog = new OpenFileDialog();
      var result = openFileDialog.ShowDialog();

      if (result.GetValueOrDefault())
      {
        _filePath = openFileDialog.FileName;
      }
    }

    private void OnCmdSpeichern()
    {
      if (CheckRequiredFields())
      {
        _metadataItem = new MetadataItem(this);
        _fileSystemService.AddFile(_metadataItem, IsRemoveFileEnabled, _filePath);
        _navigateBack();
      }
      else
      {
        MessageBox.Show("Es müssen alle Pflichtfelder ausgewählt werden");
      }
    }

    private bool CheckRequiredFields()
    {
      var bezeichnung = !string.IsNullOrEmpty(Bezeichnung);
      var valutaDatum = !string.IsNullOrEmpty(ValutaDatum.ToString());
      var selectedTypItem = !string.IsNullOrEmpty(SelectedTypItem);
      var filePath = !string.IsNullOrEmpty(_filePath);

      return bezeichnung && valutaDatum && selectedTypItem && filePath;
    }
  }
}