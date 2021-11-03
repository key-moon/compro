// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2703/judge/6026023/C++17
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

bool solve() {
  int n;
  cin >> n;
  if (n == 0) return false;

  using D = pair<pair<int, int>, int>;

  vector<vector<D>> dice;
  for (int i = 0; i < n; i++) {
    int x, y;
    cin >> x >> y;
    Die<int> die;
    cin >> die.west() >> die.east() >> die.south() >> die.north() >> die.bottom() >> die.top();
    vector<D> path;
    map<pair<int, int>, int> last_ind;
    last_ind[make_pair(y, x)] = 0;
    path.emplace_back(make_pair(y, x), die.bottom());

    string s;
    cin >> s;
    for (var&& c : s) {
      var [pts, _] = path.back();
      var[y, x] = pts;
      switch (c) {
      case 'L':
        c = 'W';
        x--;
        break;
      case 'R':
        c = 'E';
        x++;
        break;
      case 'B':
        c = 'N';
        y++;
        break;
      case 'F':
        c = 'S';
        y--;
        break;
      default:
        assert(false);
        break;
      }
      
      pts = make_pair(y, x);
      die.roll(c);
      if (last_ind.count(pts)) {
        path[last_ind[pts]].second = 0;
      }
      last_ind[pts] = path.size();
      path.emplace_back(pts, die.bottom());
    }
    dice.emplace_back(path);
  }

  // duplicate_pos[i][j] := { k | dice[i][k].fst が dice[j] に含まれるもの }
  vector<vector<vector<int>>> duplicate_pos(n, vector<vector<int>>(n));

  for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
      for (int k1 = 0; k1 < dice[i].size(); k1++) {
        for (int k2 = 0; k2 < dice[j].size(); k2++) {
          if (dice[i][k1].first != dice[j][k2].first) continue;
          duplicate_pos[i][j].emplace_back(k1);
          break;
        }
      }
    }
  }

  vector<int> dp(1 << n);
  for (int b = 0; b < (1 << n); b++) {
    for (int nxt = 0; nxt < n; nxt++) {
      if (b >> nxt & 1) continue;
      vector<bool> valid(dice[nxt].size(), true);
      for (int i = 0; i < n; i++) {
        if (not (b >> i & 1)) continue;
        for (var&& pos : duplicate_pos[nxt][i]) {
          valid[pos] = false;
        }
      }
      var res = dp[b];
      for (int i = 0; i < valid.size(); i++) {
        if (not valid[i]) continue;
        res += dice[nxt][i].second;
      }
      chmax(dp[b | (1 << nxt)], res);
    }
  }

  cout << dp.back() << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


