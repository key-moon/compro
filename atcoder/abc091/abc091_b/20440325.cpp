// detail: https://atcoder.jp/contests/abc091/submissions/20440325
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  map<string, int> mp{};
  int n;
  cin >> n;
  for (int i = 0; i < n; i++) {
    string s;
    cin >> s;
    mp[s]++;
  }
  int m;
  cin >> m;
  for (int i = 0; i < m; i++) {
    string s;
    cin >> s;
    mp[s]--;
  }
  int mx = 0;
  for (var&& kv : mp) {
    chmax(mx, kv.second);
  }
  cout << mx << endl;

}
