#!/bin/bash

#================================
# codegen_all
# c:クリーンビルド
# p:終了時にポーズ
# 例：
# codegen_all.sh cp
#================================

# 現在時刻を取得
_started_at=$(date +'%s.%3N')

# 引数セットアップ.
if [ $# = 0 ]; then
    param=""
else
    param="$1"
fi

# 出力フォルダクリーン
if [[ "$param" == *c* ]]; then
  rm -rf output
fi

# サーバー側
ruby codegen.rb -i codegen_server_cs.yml

# Unity側
ruby codegen.rb -i codegen_unity_cs.yml

# マスターデータ側
sh protoc_sheet.sh


# 完了時刻を取得
_ended_at=$(date +'%s.%3N')
# 経過時間を計算
_elapsed=$(echo "scale=3; $_ended_at - $_started_at" | bc)

# 一時停止
if [[ "$param" == *p* ]]; then
  echo "start: $(date -d "@${_started_at}" +'%Y-%m-%d %H:%M:%S.%3N (%:z)')"
  echo "end  : $(date -d "@${_ended_at}" +'%Y-%m-%d %H:%M:%S.%3N (%:z)')"
  echo "dur:   $_elapsed"
  eval "echo Elapsed Time: $(date -ud "@$_elapsed" +'$((%s/3600/24)):%H:%M:%S.%3N')"
  read -p "Press [Enter] key to resume."
fi
