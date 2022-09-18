# encoding: utf-8
require "active_support/inflector"
require "fileutils"

#====================================================================
# テンプレートからコードを生成する.
#====================================================================
class CodeGenerator
  attr_accessor :message
  attr_accessor :src_path_pattern
  attr_accessor :template_path
  attr_accessor :file_suffix
  attr_accessor :out_dir_path
  attr_accessor :is_editable
  attr_accessor :is_force_update
  attr_accessor :src_base_path
  attr_accessor :out_base_path

  def initialize
    @message = ""
    @src_path_pattern = ""
    @template_path = ""
    @file_suffix = ""
    @out_dir_path = ""
    @is_editable = false
    @is_force_update = false
    @target_content_pattern = nil
    @src_base_path = ""
    @out_base_path = ""
  end

  def actual_src_path_pattern
    "#{@src_base_path}#{@src_path_pattern}"
  end

  def actual_out_dir_path
    "#{@out_base_path}#{@out_dir_path}"
  end

  #============================================================
  # コード生成実行処理.
  #============================================================
  def generate_recursive(data:)
    generator = clone()
    generator.setup_by_data(data: data)

    generator.show_message()

    items = data.dig("items")
    if items.nil?
      generator.generate_inner()
    else
      items.each do |item|
        generator.generate_recursive(data: item)
      end
    end
  end

  #============================================================
  # dataオブジェクトを使用してこのジェネレーターのセットアップを行う.
  #============================================================
  def setup_by_data(data:)
    setup(
      message: data.dig("message"),
      src_path_pattern: data.dig("src_path_pattern"),
      template_path: data.dig("template_path"),
      file_suffix: data.dig("file_suffix"),
      out_dir_path: data.dig("out_dir_path"),
      is_editable: data.dig("is_editable"),
      is_force_update: data.dig("is_force_update"),
      target_content_pattern: data.dig("target_content_pattern"),
      src_base_path: data.dig("src_base_path"),
      out_base_path: data.dig("out_base_path"),
    )
  end

  #============================================================
  # このジェネレーターのセットアップを行う.
  #============================================================
  def setup(
    message: nil,
    src_path_pattern: nil,
    template_path: nil,
    file_suffix: nil,
    out_dir_path: nil,
    is_editable: nil,
    is_force_update: nil,
    target_content_pattern: nil,
    src_base_path: nil,
    out_base_path: nil
  )
    self.message = message if !message.nil?
    self.src_path_pattern = src_path_pattern if !src_path_pattern.nil?
    self.template_path = template_path if !template_path.nil?
    self.file_suffix = file_suffix if !file_suffix.nil?
    self.out_dir_path = out_dir_path if !out_dir_path.nil?
    self.is_editable = is_editable if !is_editable.nil?
    self.is_force_update = is_force_update if !is_force_update.nil?
    self.target_content_pattern = target_content_pattern if !target_content_pattern.nil?
    self.src_base_path = src_base_path if !src_base_path.nil?
    self.out_base_path = out_base_path if !out_base_path.nil?
    self
  end

  #====================================================================
  # テンプレートからコードを生成する.
  #====================================================================
  def generate_inner()
    # 出力先フォルダがなければ生成.
    FileUtils.mkdir_p(actual_out_dir_path)
    src_file_paths = Dir.glob(actual_src_path_pattern)

    src_file_paths.each do |src_file_path|
      generate_code(src_file_path: src_file_path)
    end
    self
  end

  def show_message()
    puts message if !message.nil?
  end

  #====================================================================
  # テンプレートからコードを生成する.
  #====================================================================
  def generate_code(
    src_file_path:
  )
    file_prefix = File.basename(src_file_path, ".*").camelize
    out_file_path = "#{actual_out_dir_path}/#{file_prefix}#{file_suffix}"

    # 更新不要ならスキップ.
    skip = false
    if File.exist?(out_file_path)
      skip = true
      # 編集不能なコードはソース、テンプレートの更新あったらスキップしない.
      if !is_editable
        skip &= (File.mtime(src_file_path) < File.mtime(out_file_path))
        skip &= (File.mtime(template_path) < File.mtime(out_file_path))
      end
    end
    skip = false if is_force_update
    return if skip

    # コード生成コマンド実行.
    command = "bin/protoc --csharp-template_out=template=#{template_path},"
    command += "fileSuffix=#{file_suffix}:#{actual_out_dir_path} "
    command += "--plugin=plugin/protoc-gen-csharp-template #{src_file_path}"
    `#{command}`

    if File.exist?(out_file_path)
      puts "generate_innerCode Source:#{out_file_path}"
    end
  end
end
