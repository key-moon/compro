// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3206/judge/4974926/C++17
//This code was written at a mock domestic contest on 2020/10/25

#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

//
//    0
//  1 2 3 4
//    5
//
//

#include <bits/stdc++.h>
using namespace std;

struct Die {
  array<int, 6> fs;
  Die() {
    for (int i = 0; i < 6; i++){
      fs[i] = -1;
    }
  }
};

char toChar(int n){
  if (n == 0) return '^';
  if (n == 1) return '>';
  if (n == 2) return 'v';
  if (n == 3) return '<';
  assert(false);
  return -1;
}

void Print(Die d){
  cout << " " << toChar(d.fs[4]) << "   " << endl;
  cout << toChar(d.fs[3]) << toChar(d.fs[0]) << toChar(d.fs[2]) << toChar(d.fs[5]) << endl;
  cout << " " << toChar(d.fs[1]) << "   " << endl;
}

Die RotateUp(Die die){
  Die res;
  res.fs[0] = die.fs[1];
  res.fs[1] = die.fs[5] + 2;
  res.fs[2] = die.fs[2] + 1;
  res.fs[3] = die.fs[3] + 3;
  res.fs[4] = die.fs[0];
  res.fs[5] = die.fs[4] + 2;

  for (int i = 0; i < 6; ++i) {
    res.fs[i] += 4;
    res.fs[i] %= 4;
  }

  return res;
}

Die RotateRight(Die die){
  Die res = die;
  res.fs[2] = die.fs[1];
  res.fs[4] = die.fs[2];
  res.fs[1] = die.fs[3];
  res.fs[3] = die.fs[4];

  for (int i = 0; i < 6; ++i) {
    res.fs[i] = (res.fs[i] + 3) % 4;
  }
  res.fs[5] += 2;
  res.fs[5] %= 4;

  return res;
}

int v[6][4] = {{4, 2, 1, 3}, //0
               {0, 2, 5, 3}, //1
               {4, 5, 1, 0}, //2
               {4, 0, 1, 5}, //3 
               {5, 2, 0, 3}, //4
               {4, 3, 1, 2}};//5

//今自分が上で、隣接にそれがあった場合の頭の方向
int ang[6][4] = {{0, 0, 0, 0}, //0
                 {0, 1, 2, 3}, //1
                 {1, 0, 3, 0}, //2
                 {3, 0, 1, 0}, //3 
                 {2, 3, 0, 1}, //4
                 {2, 0, 2, 0}};//5

int dys[4] = { -1, 0, 1, 0 };
int dxs[4] = { 0, 1, 0, -1 };

struct State{
  int y;
  int x;
  int ind;
  int head;
  State(int y, int x, int ind, int head) : y(y), x(x), ind(ind), head(head){}
};

int getDirID(char c){
  if (c == '^') return 0;
  if (c == '>') return 1;
  if (c == 'v') return 2;
  if (c == '<') return 3;
  assert(false);
  return -1;
}

Die readDie(){
  vector<string> s(1 + 5 + 1);
  for (int i = 1; i <= 5; i++){
    cin >> s[i];
    s[i] = "." + s[i] + ".";
  }
  s[0] = s[6] = string(1 + 5 + 1, '.');
  int sty = -1, stx = -1;
  for (int i = 0; i < 7; i++){
    for (int j = 0; j < 7; j++){
      if (s[i][j] != '.'){
        sty = i; stx = j;
        goto end;
      }
    }
  }
  end:;
  stack<State> state{};
  state.push(State(sty, stx, 0, 0));

  Die res{};
  
  while (!state.empty()){
    var elem = state.top(); state.pop();
    int cury = elem.y;
    int curx = elem.x;
    int curind = elem.ind;
    int curhead = elem.head; //実際の展開図上での頭の向き
    for (int i = 0; i < 4; i++){
      int ny = cury + dys[i];
      int nx = curx + dxs[i];
      if (s[ny][nx] == '.') continue;

      //今の上の方向を上にした時のマジの方向
      //curhead==iの時、dir=0になるべき
      int realDir = (i - curhead + 4) % 4;

      int nind = v[curind][realDir];
      //angは今の回転を考慮していない方向なので、戻す必要がある
      int nhead = (ang[curind][realDir] + curhead) % 4;

      //実際の上の方向に補正したID
      var id = (getDirID(s[ny][nx]) - nhead + 4) % 4;

      if (res.fs[nind] != -1){
        assert(res.fs[nind] == id);
        continue;
      }
      res.fs[nind] = id;

      state.push(State(ny, nx, nind, nhead));
    }
  }
  return res;
}

int diff(const Die &a, const Die &b) {
  int res = 0;
  for (int i = 0; i < 6; ++i) {
    if (a.fs[i] == b.fs[i]) continue;
    res++;
  }

  return res;
}

int rot4(Die a, const Die &b) {
  int res = 10;
  for (int i = 0; i < 4; ++i) {
    a = RotateRight(a);
    chmin(res, diff(a, b));
  }

  return res;
}

int calc(Die a, const Die &b) {
  int res = 6;

  // top: 0
  chmin(res, rot4(a, b));
  
  // top: 1
  chmin(res, rot4(RotateUp(a), b));

  // top: 2
  a = RotateRight(a);
  chmin(res, rot4(RotateUp(a), b));

  // top: 4
  a = RotateRight(a);
  chmin(res, rot4(RotateUp(a), b));

  // top: 3
  a = RotateRight(a);
  chmin(res, rot4(RotateUp(a), b));

  // top: 5
  a = RotateUp(a);
  a = RotateUp(a);
  chmin(res, rot4(a, b));

  return res;
}

bool solve(){
  int n;
  cin >> n;
  if (n == 0) return false;
  vector<Die> dice(n);
  for (int i = 0; i < n; i++){
    dice[i] = readDie();
    //Print(dice[i]);
    //cout << endl;
  }
  for (int i = 0; i < n; ++i) {
    for (int j = 0; j < n; ++j) {
      cout << calc(dice[i], dice[j]);
    }
    cout << newl;
  }
  return true;
}


int main(){
  while (solve()){}
}

