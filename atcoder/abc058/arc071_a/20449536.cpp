// detail: https://atcoder.jp/contests/abc058/submissions/20449536
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<int> cnt(256, INT_MAX);
  for (int i = 0; i < n; i++) {
    string s;
    cin >> s;
    vector<int> tmp(256);
    for (var&& c : s) tmp[c]++;
    for (int i = 0; i < 256; i++) chmin(cnt[i], tmp[i]);
  }
  for (int i = 0; i < 256; i++) {
    for (int j = 0; j < cnt[i]; j++) cout << (char)i;
  }
  cout << endl;
}
