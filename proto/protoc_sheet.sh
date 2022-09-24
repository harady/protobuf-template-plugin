#!/bin/sh

protoc=bin/protoc

masterdir=./output/master_data

mkdir -p ${masterdir}

#============================================================
# スプレッドシートカラム名を生成.
#============================================================
echo "スプレッドシートカラム名を生成."

sheet_columns_folder=sheet_columns
rm -rf ${sheet_columns_folder}
mkdir -p ${sheet_columns_folder}
filepaths=$(find ./table -type f -name "*.proto")

for filepath in ${filepaths} ; do
    echo ">>> ${filepath}"
    # .
    ${protoc} --csharp-template_out=template=template/sheet_columns.gotemplate,fileSuffix=.txt:${sheet_columns_folder} \
        --plugin=plugin/protoc-gen-csharp-template ${filepath}
done


#============================================================
# ファイルを結合(スプレッドシート用).
#============================================================
shopt -s nocaseglob
echo "ファイルを結合(スプレッドシート用)."
prevpath=_
sheet_columns=sheet_columns.txt
books=books.txt

for filepath in ${filepaths} ; do
    filename=$(basename $filepath ".proto")
    filename=${filename//_/}
    textpath=${sheet_columns_folder}/${filename}.txt
    dirpath=$(dirname ${filepath})
    dirpath=${dirpath##*/}

    if [ ${dirpath} != ${prevpath} ]; then
        echo >> ${sheet_columns}
        echo ■${dirpath} >> ${sheet_columns}
    fi
    if [ -e ${textpath} ]; then
        cat ${textpath} >> ${sheet_columns}
        echo "" >> ${sheet_columns}
    fi
    
    prevpath=${dirpath}
done

# ブックリストを取得.
grep "■master" ${sheet_columns} > ${books}
sed -i -e "s/■//g" ${books}

mv ${sheet_columns} ${masterdir}
mv ${books} ${masterdir}


#============================================================
# ファイルを結合(マスターコレクションリスト).
#============================================================
shopt -s nocaseglob
echo "ファイルを結合(マスターコレクションリスト)."
collections=master_collections.dat

for filepath in ${filepaths} ; do
    filename=$(basename $filepath ".proto")
    filename=${filename//_/}
    textpath=${sheet_columns_folder}/${filename}.txt

    # マスターコレクション名のみをリストアップ.
    if [[ ${filepath} == *master_* ]]; then
      if [ -e ${textpath} ]; then
        head ${textpath} -n 1 >> ${collections}
      fi
    fi
done

sed -i -e "s/・//g" ${collections}

mv ${collections} ${masterdir}

#read -p "Press [Enter] key to resume."
