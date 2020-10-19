// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2612/judge/4924574/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

const int realh = 19;
const int realw = 15;

const int h = realh + 2;
const int w = realw + 2;

int black_count;
int pos_count;
int id[h][w];
vector<string> s(h);

vector<bool> arrived;

int encode(int state, int y, int x){
  return ((y * w + x) << black_count) + state;
}

void decode(int id, int& state, int& y, int& x){
  state = id & ((1 << black_count) - 1);
  var yx = id >> black_count;
  y = yx / w;
  x = yx % w;
}

int dys[] = { -1, -1, -1,  0, 0,  1, 1, 1 };
int dxs[] = { -1,  0,  1, -1, 1, -1, 0, 1 };

bool in(int i, int mx){
  return 0 <= i && i < mx;
}

void solve(){
  for (int i = 1; i <= realh; i++) {
    cin >> s[i];
    s[i] = "." + s[i] + ".";
  }
  s[0] = s[h - 1] = string(w, '.');
  for (int i = 0; i < h; i++){
    for (int j = 0; j < w; j++){
      id[i][j] = -1;
    }
  }

  int sy, sx;
  int sid = 0;
  for (int i = 1; i <= realh; i++){
    for (int j = 1; j <= realw; j++){
      if (s[i][j] == 'X'){
        id[i][j] = sid++;
      }
      else{    
        if (s[i][j] == 'O'){
          sy = i, sx = j;
        }
      }
    }
  }

  black_count = sid;
  arrived = vector<bool>((1 << black_count) * (h * w));

  vector<int> prevs{encode((1 << black_count) - 1, sy, sx)};
  for (int step = 1; prevs.size() != 0; step++){
    vector<int> nexts{};
    for (var&& elem : prevs){
      int sstate, sy, sx;
      decode(elem, sstate, sy, sx);

      for (int i = 0; i < 8; i++){
        var dy = dys[i], dx = dxs[i];
        var y = sy + dy, x = sx + dx;
        var state = sstate;
        bool isin;
        while (in(y, h) && in(x, w)){
          if (s[y][x] != 'X') break;
          if (!(state >> id[y][x] & 1)) break;
          state -= 1 << id[y][x];
          y += dy; x += dx;
        }
        //飛び越えてない
        if (state == sstate) continue;
        //飛び越えてOoBに行くことはないので、飛び越え判定のみでなんとかする
        var code = encode(state, y, x);
        if (arrived[code]) continue;
        arrived[code] = true;
        var xedge = x == 0 || x == w - 1;
        if (y == h - 1 || (y == h - 2 && !xedge)) goto found;
        if (y == 0 || xedge) continue;
        nexts.push_back(code);
      }
    }
    prevs = move(nexts);
    continue;
    found:;
    cout << step << endl;
    goto end;
  }
  cout << -1 << endl;
  end:;
}

int main(){
  solve();
}

