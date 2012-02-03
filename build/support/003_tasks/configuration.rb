task :copy_config_files do
  config_files = FileList.new("source/config/*.erb")

  config_files.each do |file|
      [configatron.artifacts_dir,configatron.app_dir].each do|folder|
        FileUtils.cp(file.name_without_template_extension,
        folder.join(file.base_name_without_extension))
      end
  end
end
