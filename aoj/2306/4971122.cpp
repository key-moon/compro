// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2306/judge/4971122/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, m;
  cin >> n >> m;
  vector<vector<ll>> mat(n, vector<ll>(n, 0));
  for (int i = 0; i < m; i++){
    int s, t, c;
    cin >> s >> t >> c;
    s--, t--;
    mat[s][t] = c;
    mat[t][s] = c;
  }
  vector<vector<int>> cliques{vector<int>{}};
  for (int i = 0; i < n; i++){
    var newqs = cliques;
    for (var&& clique : cliques){
      bool valid = true;
      for (var&& vert : clique){
        if (mat[vert][i] == 0){
          valid = false;
          break;
        }
      }
      if (!valid) continue;
      var newq = clique;
      newq.emplace_back(i);
      newqs.emplace_back(newq);
    }
    cliques = move(newqs);
  }
  ll res = 0;
  for (var&& clique : cliques){
    ll score = 0;
    for (var&& s : clique){
      ll mn = LLONG_MAX;
      for (var&& t : clique){
        if (s == t) continue;
        chmin(mn, mat[s][t]);
      }
      if (mn == LLONG_MAX) mn = 0;
      score += mn;
    }
    chmax(res, score);
  }
  cout << res << endl;
  return 0;
}

