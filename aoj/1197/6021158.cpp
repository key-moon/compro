// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1197/judge/6021158/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename T = int>
struct Die {
  array<T, 6> fs;
  int& top() { return fs[0]; }
  int& south() { return fs[1]; }
  int& east() { return fs[2]; }
  int& west() { return fs[3]; }
  int& north() { return fs[4]; }
  int& bottom() { return fs[5]; }

  int sum() { return fs[0] + fs[1] + fs[2] + fs[3] + fs[4] + fs[5]; }

  void roll(char c) {
    //the view from above
    // N
    //W E
    // S
    string b("EWNSRL");
    int v[6][4] = { {0,3,5,2},
                 {0,2,5,3},
                 {0,1,5,4},
                 {0,4,5,1},
                 {1,2,4,3},
                 {1,3,4,2} };
    for (int k = 0; k < 6; k++) {
      if (b[k] != c) continue;
      int t = fs[v[k][0]];
      fs[v[k][0]] = fs[v[k][1]];
      fs[v[k][1]] = fs[v[k][2]];
      fs[v[k][2]] = fs[v[k][3]];
      fs[v[k][3]] = t;
      break;
    }
  }
  using ll = long long;
  ll hash() {
    ll res = 0;
    for (int i = 0; i < 6; i++) res = res * 256 + fs[i];
    return res;
  }
  bool operator==(const Die& d) const {
    for (int i = 0; i < 6; i++) if (fs[i] != d.fs[i]) return 0;
    return 1;
  }
};

template<typename T>
vector<Die<T>> makeDice(Die<T> d) {
  vector<Die<T>> res;
  for (int i = 0; i < 6; i++) {
    Die t(d);
    if (i == 1) t.roll('N');
    if (i == 2) t.roll('S');
    if (i == 3) t.roll('S'), t.roll('S');
    if (i == 4) t.roll('L');
    if (i == 5) t.roll('R');
    for (int k = 0; k < 4; k++) {
      res.emplace_back(t);
      t.roll('E');
    }
  }
  return res;
}

string rotates("ENSW");
bool is_valid(Die<int>& die) {
  int sum = die.sum();
  if (sum == 0) return true;
  if (sum % 2 == 1) {
    for (var&& c : rotates) {
      var nxt = die;
      nxt.roll(c);
      if (nxt.bottom() == 0) continue;
      nxt.bottom()--;
      if (is_valid(nxt)) return true;
    }
    return false;
  }

  int X = die.fs[2] + die.fs[3];
  int Y = die.fs[1] + die.fs[4];
  int Z = die.fs[0] + die.fs[5];

  if (X > Y) swap(Y, X);
  if (X + Y < Z) return true;
  if (Z < Y - X) return false;
  Z -= Y - X;

  return Z % 2 == 0;
}

bool solve() {
  vector<int> t(6);
  for (var&& elem : t) cin >> elem;
  var sum = accumulate(t.begin(), t.end(), 0);
  if (sum == 0) return false;
  int p, q;
  cin >> p >> q;

  string res;

  sort(t.begin(), t.end());
  do
  {
    Die die;
    for (int i = 0; i < t.size(); i++) die.fs[i] = t[i];
    
    // if (die.bottom() == 0) continue;
    // die.bottom()--;

    bool same = res.size() == sum;

    string cur_res = "";
    for (int cnt = 0; cnt < sum; cnt++) {
      for (var c : rotates) {
        // 枝刈り
        if (same && res[cnt] < c) break;

        var nxt = die;
        nxt.roll(c);
        if (nxt.bottom() == 0) continue;
        nxt.bottom()--;

        if (is_valid(nxt)) {
          die = nxt;
          cur_res += c;
          if (same && cur_res[cnt] < res[cnt]) same = false;
          goto end;
        }
      }
      break;
    end:;
    }

    if (cur_res.size() != sum) continue;
    res = cur_res;

  } while (next_permutation(t.begin(), t.end()));

  if (res == "") {
    cout << "impossible" << endl;
  }
  else {
    cout << res.substr(p - 1, q - p + 1) << endl;
  }

  
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve()){}
}

