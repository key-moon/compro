// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2847/judge/4929473/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 > inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 > inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  int n;
  cin >> n;
  int N = n * n;
  int M = 2 * n * n - 2 * n;
  vector<vector<int>> g(N);
  for (int i = 0; i < M; i++){
    int r, c;
    cin >> r >> c;
    r--; c--;
    g[r].push_back(c);
    g[c].push_back(r);
  }
  vector<bool> used(N);

  queue<int> q{};
  int prev;
  for (int i = 0; i < N; i++){
    if (g[i].size() == 2){
      prev = i;
    }
  }
  q.push(prev);
  used[prev] = true;
  prev = g[prev][0];
  q.push(prev);
  used[prev] = true;
  while (g[prev].size() != 2){
    for (var&& elem : g[prev]){
      if (used[elem] || g[elem].size() == 4) continue;
      prev = elem;
      break;
    }
    q.push(prev);
    used[prev] = true;
  }
  
  for (int i = 0; i < n; i++){
    for (int j = 0; j < n; j++){
      var elem = q.front(); q.pop();
      if (j != 0) cout << ' ';
      cout << (elem + 1);
      for (var&& item : g[elem]){
        if (used[item]) continue;
        q.push(item);
        used[item] = true;
      }
    }
    cout << endl;
  }
}
